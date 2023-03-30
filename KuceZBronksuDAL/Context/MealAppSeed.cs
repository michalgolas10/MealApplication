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
            var recipess = TempDb.Recipes;
            int i = 0;
            Recipe recip1 = new()
            {
                Label = "Kupa"
            };
            context.Recipes.Add(recip1);
            //Tutaj dodać rzeczy do bazy 
            context.SaveChanges();
        }
    }
}
