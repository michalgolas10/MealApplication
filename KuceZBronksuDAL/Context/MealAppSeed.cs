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
            foreach (var recipe in Entry)
            {
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


