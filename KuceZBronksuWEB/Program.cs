using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuDAL.Repository;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using KuceZBronksuWEB.Services;
using Microsoft.EntityFrameworkCore;
using KuceZBronksuDAL.Context;

namespace KuceZBronksuWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MealAppContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksuWEB;TrustServerCertificate=True;Integrated Security=true;")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ISearch<RecipeViewModel>, SearchService>();

            var app = builder.Build();
            KuceZBronksuLogic.DataFileHandler.ReadingDataFromFile();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

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