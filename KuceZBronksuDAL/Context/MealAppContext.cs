using KuceZBronksuDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KuceZBronksuDAL.Context
{
    public class MealAppContext : DbContext
    {
        public MealAppContext(DbContextOptions<MealAppContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavouritesRecipes> FavouritesRecipes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksuWEB;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("KuceZBronksuWEB"));
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
            .Property(p => p.DietLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.HealthLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.Cautions)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.IngredientLines)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.RecipeSteps)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.CuisineType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.MealType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<FavouritesRecipes>()
            .HasKey(bc => new { bc.RecipeId, bc.UserId });
            modelBuilder.Entity<FavouritesRecipes>()
                .HasOne(bc => bc.Recipe)
                .WithMany(b => b.RecipeFavouritesUsers)
                .HasForeignKey(bc => bc.RecipeId);
            modelBuilder.Entity<FavouritesRecipes>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UsersFavouritesRecipies)
                .HasForeignKey(bc => bc.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}