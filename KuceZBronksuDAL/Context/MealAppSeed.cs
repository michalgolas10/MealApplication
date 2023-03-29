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
            foreach()
            
            //Tutaj dodać rzeczy do bazy 
            context.SaveChanges();
        }
    }
}
