using KuceZBronksuDAL.FilesHandlers;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuDAL.Context
{
    public class MealAppSeed
    {
        public static void Initialize(MealAppContext context)
        {
            context.Database.EnsureCreated();
            if (context.Recipes.Any())
                return;
            DataFileHandler.ReadingDataFromFile();
            var testUser = new User() { Name = "Michał"};
            context.Users.Add(testUser);
            foreach (var recipe in TempDb.Recipes)
            {
                context.Recipes.Add(recipe);
            }
            context.SaveChanges();

            //Tutaj dodać rzeczy do bazy
        }
    }
}