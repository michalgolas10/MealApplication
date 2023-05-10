using KuceZBronksuDAL;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuBLL
{
	public class Search
	{
		public static List<Recipe> SearchByIngredients(List<string> products)
		{
			//Przykładowe dane wejściowe
			//List<string> list = new List<string>() { "mulberries", "sugar" };
			//var wynik = Search.SearchByIngredients(list);

			List<Recipe> result = new List<Recipe>();
			if (products != null)
			{
				foreach (var recipe in TempDb.Recipes)
				{
					if (products.All(x => recipe.IngredientLines.Any(i => i.Contains(x, StringComparison.CurrentCultureIgnoreCase))))
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> SearchByIngredients(List<string> products, List<Recipe> database)
		{
			//Przykładowe dane wejściowe
			//List<string> list = new List<string>() { "mulberries", "sugar" };
			//List<Recipe> = database;
			//var wynik = Search.SearchByIngredients(list, database);

			List<Recipe> result = new List<Recipe>();
			if (products != null)
			{
				foreach (var recipe in database)
				{
					if (products.All(x => recipe.IngredientLines.Any(i => i.Contains(x, StringComparison.CurrentCultureIgnoreCase))))
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> SearchByMealType(List<string> mealType)
		{
			//Przykładowe dane wejściowe
			//List<string> list = new List<string>() {"lunch/dinner","teatime"};
			//var wynik = Search.SearchByMealType(list);

			List<Recipe> result = new List<Recipe>();
			if (mealType != null)
			{
				foreach (var recipe in TempDb.Recipes)
				{
					if (mealType.All(x => recipe.MealType.Any(i => i.Equals(x, StringComparison.CurrentCultureIgnoreCase))))
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> SearchByMealType(List<string> mealType, List<Recipe> database)
		{
			//Przykładowe dane wejściowe
			//List<string> list = new List<string>() {"lunch/dinner","teatime"};
			//List<Recipe> = database;
			//var wynik = Search.SearchByMealType(list, database);

			List<Recipe> result = new List<Recipe>();
			if (mealType != null)
			{
				foreach (var recipe in database)
				{
					if (mealType.All(x => recipe.MealType.Any(i => i.Equals(x, StringComparison.CurrentCultureIgnoreCase))))
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> SearchByKcal(double kcal, double margin)
		{
			//Przykładowe dane wejściowe
			//var wynik = Search.SearchByKcal(1500d,150d);

			List<Recipe> result = new List<Recipe>();
			if (kcal > 0 && margin >= 0)
			{
				foreach (var recipe in TempDb.Recipes)
				{
					if (Math.Abs(recipe.Calories - kcal) <= margin)
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> SearchByKcal(double kcal, double margin, List<Recipe> database)
		{
			//Przykładowe dane wejściowe
			//List<Recipe> = database;
			//var wynik = Search.SearchByKcal(1500d,150d,database);

			List<Recipe> result = new List<Recipe>();
			if (kcal > 0 && margin >= 0)
			{
				foreach (var recipe in database)
				{
					if (Math.Abs(recipe.Calories - kcal) <= margin)
					{
						result.Add(recipe);
					}
				}
			}
			return result;
		}

		public static List<Recipe> DrawRecipesForDay(double amountoOfDailyCalories)
		{
			var nameOfMeal = new List<string>() { "breakfast" };
			List<Recipe> listOfBreakfast = new();
			List<Recipe> listOfTeatime = new();
			List<Recipe> listOfDinner = new();
			foreach (var recipe in SearchByMealType(nameOfMeal))
			{
				foreach (var recipe2 in SearchByKcal(amountoOfDailyCalories * 0.3, 150d))
				{
					if (recipe == recipe2)
					{
						listOfBreakfast.Add(recipe);
					}
				}
			}
			nameOfMeal[0] = "Teatime";
			foreach (var recipe in SearchByMealType(nameOfMeal))
			{
				foreach (var recipe2 in SearchByKcal(amountoOfDailyCalories * 0.3, 150d))
				{
					if (recipe == recipe2)
					{
						listOfTeatime.Add(recipe);
					}
				}
			}
			nameOfMeal[0] = "Lunch/Dinner";
			foreach (var recipe in SearchByMealType(nameOfMeal))
			{
				foreach (var recipe2 in SearchByKcal(amountoOfDailyCalories * 0.25, 150d))
				{
					if (recipe == recipe2)
					{
						listOfDinner.Add(recipe);
					}
				}
			}
			if (!(listOfBreakfast.Count == 0 || listOfTeatime.Count == 0 || listOfDinner.Count == 0))
			{
				var random = new Random();
				var indexbrk = random.Next(listOfBreakfast.Count);
				var indexteatime = random.Next(listOfTeatime.Count);
				var indexlunchdinner = random.Next(listOfDinner.Count);
				List<Recipe> listofrandoms = new List<Recipe>() { listOfBreakfast[indexbrk], listOfTeatime[indexteatime], listOfDinner[indexlunchdinner] };
				double amountofleftcalories = amountoOfDailyCalories - listOfBreakfast[indexbrk].Calories - listOfTeatime[indexteatime].Calories - listOfDinner[indexlunchdinner].Calories;
				//var amountofcaloriesleft = $"Pozostała liczba kalorii do wykorzystania tego dnia: {amountofleftcalories}";
				return listofrandoms;
			}
			else
			{
				Recipe Recipe = new Recipe();
				List<Recipe> list = new List<Recipe>();
				return list;
			}
		}
	}
}