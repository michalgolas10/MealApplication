using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;





namespace KuceZBronksuDAL.Context
{
    public class MealAppContext :IdentityDbContext<User, IdentityRole<int>, int>
	{
		public MealAppContext(DbContextOptions<MealAppContext> options) : base(options)
		{
		}

		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksuWEB;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("KuceZBronksuWEB"));
			//optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
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
            modelBuilder.Entity<User>()
			.HasMany(c => c.Recipes)
			.WithOne(e => e.User)
			.OnDelete(DeleteBehavior.ClientSetNull);
        }
	}
}