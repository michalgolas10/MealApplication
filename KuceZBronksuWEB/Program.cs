using KuceZBronksuBLL.Services;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuWEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuWEB
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<MealAppContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksuWEB;TrustServerCertificate=True;Integrated Security=true;")));

               builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MealAppContext>();
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			builder.Services.AddScoped<RecipeService>();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddControllersWithViews();
			builder.Services.AddAutoMapper(typeof(RecipeViewModel), typeof(Program));
			builder.Services.AddAutoMapper(typeof(EditAndCreateViewModel), typeof(Program));
			builder.Services.AddAutoMapper(typeof(Recipe), typeof(Program));
			var app = builder.Build();
			CreateDbIfNotExists(app);
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
               app.UseAuthentication();;

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
		}

		private static void CreateDbIfNotExists(IHost host)
		{
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<MealAppContext>();
				MealAppSeed.Initialize(context);
			}
			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "An error occurred creating the DB.");
			}
		}
	}
}