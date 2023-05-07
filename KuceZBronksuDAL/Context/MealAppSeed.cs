﻿using KuceZBronksuDAL.FilesHandlers;
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

			await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin"});
			var serviceAdmin = new User { Email = "serviceadmin@admin.com", UserName = "serviceadmin@admin.com" };

			var result = await userManager.CreateAsync(serviceAdmin);
            await userManager.AddPasswordAsync(serviceAdmin, "passworD123");
            await userManager.AddToRoleAsync(serviceAdmin, "Admin"); // todo: check if enough
            context.SaveChanges();
		}
	}
}