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
            var recipes = TempDb.Recipes;
            foreach ( var recipe in recipes ) { 
            context.Recipes.Add( recipe );
                context.Images.Add(recipe.Images );
                context.LargeImages.Add(recipe.Images.LARGE);
                context.SmallImages.Add(recipe.Images.SMALL);
                context.RegularImages.Add(recipe.Images.REGULAR);
                context.ThumbnailImages.Add(recipe.Images.THUMBNAIL);
            }
            context.SaveChanges();
            //Tutaj dodać rzeczy do bazy 
        }
    }
}
