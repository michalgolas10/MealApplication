﻿using KuceZBronksuDAL.Models;
using System.Text.Json;

namespace KuceZBronksuDAL.FilesHandlers
{
	public class DataFileHandler
	{
		public static void ReadingDataFromFile()
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			string JsonFilePath = "../KuceZBronksuDAL/JsonFiles/RecipeJson.json";
			string JsonDeserialized = File.ReadAllText(JsonFilePath);

			var recipeList = JsonSerializer.Deserialize<List<Root>>(JsonDeserialized, options);
			if (recipeList != null)
			{
				TempDb.Recipes = recipeList.Select(x => x.Recipe).ToList();
			}
			else
			{
				throw new ArgumentException("Error while deserializing file.");
			}
		}
	}
}