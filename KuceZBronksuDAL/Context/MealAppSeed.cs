using AutoMapper;
using KuceZBronksuDAL.Models;
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
        public static void Initialize(MealAppContext context,IMapper mapper)
        {
            context.Database.EnsureCreated();
            
            if (context.Recipes.Any())
            {
                return;
            }
            var recipes = TempDb.Recipes;
            var recipesDb = recipes.Select(e => mapper.Map<RecipeDb>(e)).ToList();
            foreach(var recipe in recipesDb )
            {
                context.Recipes.Add(recipe);
            }
            context.SaveChanges();
            //Tutaj dodać rzeczy do bazy 
        }
    }
}
