using KuceZBronksuDAL.Models;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:kuce-z-bronksu-db.database.windows.net,1433;Initial Catalog=KuceZBronksu;Persist Security Info=False;User ID=dziunia;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("KuceZBronksu"));
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
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Users)
                .WithMany(x => x.Recipes)
                .UsingEntity(j => j.ToTable("FavouritesRecipes"));
            base.OnModelCreating(modelBuilder);
        }
    }
}