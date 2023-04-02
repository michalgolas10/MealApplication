using AutoMapper;
using KuceZBronksuDAL.Models;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Context
{
    public class MealAppSeed
    {
        public static void Initialize(MealAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
            {
                return;
            }
            var recipesDb = MapFromRecipeToRecipeDb(TempDb.Recipes);
            foreach (var recipe in recipesDb)
            {
                context.Recipes.Add(recipe);
            }
            context.SaveChanges();
            //Tutaj dodać rzeczy do bazy 
        }
        public static List<RecipeDb> MapFromRecipeToRecipeDb(List<Recipe> Entry)
        {
            List<RecipeDb> Result = new();
            Images EmptyImages = new Images()
            {
                LARGE = new LARGE() { Url="Empty", Height = 0, Width = 0},
                SMALL = new SMALL() { Url = "Empty", Height = 0, Width = 0 },
                REGULAR = new REGULAR() { Url = "Empty", Height = 0, Width = 0 },
                THUMBNAIL = new THUMBNAIL() { Url = "Empty", Height = 0, Width = 0 },
            };
            foreach (var recipe in Entry)
            {
                if (recipe.Label == null) { recipe.Label = "Empty"; }
                if (recipe.ShareAs == null) { recipe.ShareAs = "Empty"; }
                if (recipe.DietLabels == null) { recipe.DietLabels = new List<string>() { "Empty" }; }
                if (recipe.HealthLabels == null) { recipe.HealthLabels = new List<string>() { "Empty" }; }
                if (recipe.Cautions == null) { recipe.Cautions = new List<string>() { "Empty" }; }
                if (recipe.IngredientLines == null) {recipe.IngredientLines = new List<string>() { "Empty" };}
            if (recipe.RecipeSteps == null) { recipe.RecipeSteps = new List<string>() { "Empty" }; }
                if (recipe.Calories == null) { recipe.Calories = 0; }
                if (recipe.CuisineType == null) { recipe.CuisineType = new List<string>() { "Empty" }; }
                if (recipe.MealType == null) { recipe.MealType = new List<string>() { "Empty" }; }
                if (recipe.Images == null) { recipe.Images = EmptyImages; }
                if (recipe.Images.THUMBNAIL == null) { recipe.Images.THUMBNAIL = EmptyImages.THUMBNAIL; }
                if (recipe.Images.SMALL == null) { recipe.Images.SMALL = EmptyImages.SMALL; }
                if (recipe.Images.REGULAR == null) { recipe.Images.REGULAR = EmptyImages.REGULAR; }
                if (recipe.Images.LARGE == null) { recipe.Images.LARGE = EmptyImages.LARGE; }
                RecipeDb recipeDb = new()
                {
                    Label = recipe.Label,
                    ShareAs = recipe.ShareAs,
                    DietLabels = recipe.DietLabels,
                    HealthLabels = recipe.HealthLabels,
                    Cautions = recipe.Cautions,
                    IngredientLines = recipe.IngredientLines,
                    RecipeSteps = recipe.RecipeSteps,
                    Calories = recipe.Calories,
                    CuisineType = recipe.CuisineType,
                    MealType = recipe.MealType,
                };
                if(recipe.Images.LARGE==null)
                    recipeDb.Images = recipe.Images.SMALL.Url;
                else recipeDb.Images = recipe.Images.LARGE.Url;
                Result.Add(recipeDb);
            }
            return Result;
        }
    }
}


