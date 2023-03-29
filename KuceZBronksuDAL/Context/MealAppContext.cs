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

namespace KuceZBronksuDAL.Context
{
    public class MealAppContext : DbContext
    {
        public MealAppContext(DbContextOptions<MealAppContext> options) : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<LARGE> LargeImages { get; set; }
        public DbSet<SMALL> SmallImages { get; set; }
        public DbSet<REGULAR> RegularImages { get; set; }
        public DbSet<THUMBNAIL> ThumbnailImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KuceZBronksu;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("Ex7"));
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
                .HasOne<Images>();
            modelBuilder.Entity<Images>()
                .HasOne<SMALL>();
            modelBuilder.Entity<Images>()
                .HasOne<LARGE>();
            modelBuilder.Entity<Images>()
                .HasOne<THUMBNAIL>();
            modelBuilder.Entity<Images>()
                .HasOne<REGULAR>();
            modelBuilder.Entity<User>()
                .HasMany<Recipe>();
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
