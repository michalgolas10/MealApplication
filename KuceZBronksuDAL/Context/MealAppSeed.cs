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
            foreach (var recipe in TempDb.Recipes)
            {
                var mad = TempDb.Recipes;
                context.Recipes.Add(recipe);
                context.Images.Add(recipe.Images);
                context.LargeImages.Add(recipe.Images.LARGE);
                context.SmallImages.Add(recipe.Images.SMALL);
                context.ThumbnailImages.Add(recipe.Images.THUMBNAIL);
                context.RegularImages.Add(recipe.Images.REGULAR);
            }
            //Tutaj dodać rzeczy do bazy 
            context.SaveChanges();
        }
    }
}
