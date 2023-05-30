using Hangfire;
using KuceZBronksuBLL.ConfigurationMail;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuWEB.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Globalization;
using System.Reflection;

namespace KuceZBronksuWEB
{
    public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<MealAppContext>(options =>
			options.UseSqlServer("name=AuthDbContextConnection"));
			var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddHangfire(configuration => configuration
			.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UseSqlServerStorage(connectionstring, new Hangfire.SqlServer.SqlServerStorageOptions
			{
				CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
				SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
				QueuePollInterval = TimeSpan.Zero,
				UseRecommendedIsolationLevel = true,
				DisableGlobalLocks = true,
			}));
			builder.Host.UseSerilog((context, configuration) =>
			configuration.ReadFrom.Configuration(context.Configuration));
			builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
			builder.Services.AddHangfireServer();

			builder.Services.AddSingleton<LanguageService>();
			builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

			builder.Services.AddMvc()
				.AddViewLocalization()
				.AddDataAnnotationsLocalization(options =>
				{	
					options.DataAnnotationLocalizerProvider = (type, factory) =>
					{
						var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);
						return factory.Create("ShareResource", assemblyName.Name);
					};
				});
			builder.Services.Configure<RequestLocalizationOptions>(
				options =>
				{
					var supportedCultures = new List<CultureInfo>
					{
						new CultureInfo("en-US"),
						new CultureInfo("pl-PL"),
                        new CultureInfo("de-DE"),
                    };

					options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
					options.SupportedCultures = supportedCultures;
					options.SupportedUICultures= supportedCultures;
					options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
				}
			);
			builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
					.AddRoles<IdentityRole<int>>()
					.AddEntityFrameworkStores<MealAppContext>()
					.AddDefaultTokenProviders()
					.AddDefaultUI();
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			builder.Services.AddTransient<IReportService, ReportService>();
			builder.Services.AddTransient<IRecipeService, RecipeService>();
			builder.Services.AddTransient<ITimeService, TimeService>();
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IGetReportService, GetReportService>();
			builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
			builder.Services.AddTransient<IMailService, MailService>();
			builder.Services.AddControllersWithViews();
			builder.Services.AddAutoMapper(typeof(RecipeViewModel), typeof(Program));
			builder.Services.AddAutoMapper(typeof(EditAndCreateViewModel), typeof(Program));
			builder.Services.AddAutoMapper(typeof(Recipe), typeof(Program));
			builder.Services.AddAutoMapper(typeof(User), typeof(Program));
			builder.Services.AddHttpClient();
			var app = builder.Build();
			await CreateDbIfNotExists(app);

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			var IocOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(IocOptions.Value);
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication(); ;
			app.UseSerilogRequestLogging();

			app.UseAuthorization();
			app.UseHangfireDashboard();
			app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			RecurringJob.AddOrUpdate<ITimeService>("SendEmailToAdmin", service => service.SendEmailToAdmin(), Cron.Minutely);
			app.MapRazorPages();

			app.Run();
		}

		private static async Task CreateDbIfNotExists(IHost host)
		{
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<MealAppContext>();
				var userManager = services.GetRequiredService<UserManager<User>>();
				var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
				await MealAppSeed.Initialize(context, userManager, roleManager);
			}
			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "An error occurred creating the DB.");
			}
		}
	}
}