using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using KuceZBronksuDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KuceZBronksuDAL.Context
{
    public class MealAppContext : DbContext
    {
        public MealAppContext(DbContextOptions<MealAppContext> options) : base(options)
        {
        }
        public DbSet<RecipeDb> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksuWEB;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("KuceZBronksuWEB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.DietLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.HealthLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.Cautions)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.IngredientLines)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.RecipeSteps)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.CuisineType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
            .Property(p => p.MealType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<RecipeDb>()
                .HasMany(x => x.Users)
                .WithMany(x => x.Recipes)
                .UsingEntity(j => j.ToTable("FavouritesRecipes"));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeDb>()
                .HasOne<string>(x => x.Images)
                .WithOne();
        }
    }
}
