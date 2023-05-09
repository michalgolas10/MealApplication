using KuceZBronksuDAL.FilesHandlers;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Identity;

namespace KuceZBronksuDAL.Context
{
	public class MealAppSeed
	{
		public async static Task Initialize(MealAppContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
		{
			context.Database.EnsureCreated();
			if (context.Recipes.Any())
				return;
			DataFileHandler.ReadingDataFromFile();
			foreach (var recipe in TempDb.Recipes)
			{
				context.Recipes.Add(recipe);
			}
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "NormalUser" });
			var serviceAdmin = new User
			{
				Email = "janedoe@example.com",
				UserName = "janedoe@example.com",
				EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(serviceAdmin, "Password.123");
            await userManager.AddToRoleAsync(serviceAdmin, "Admin");
            context.SaveChanges();
        }
	}
}