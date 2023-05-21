using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Helpers
{
	public class Helpers		//KU PAMIĘCI Z TYMI HELPERSAMI 
	{
		public List<string> ListOfMealType = new List<string>()
			{
				"breakfast",
				"lunch/dinner",
				"teatime"
			};

		public List<string> HealthLabels = new List<string>()
				{
					"Vegan",
					"Vegetarian",
					"Pescatarian",
					"Dairy-Free",
					"Gluten-Free",
					"Wheat-Free",
					"Egg-Free",
					"Peanut-Free",
					"Tree-Nut-Free",
					"Soy-Free",
					"Fish-Free",
					"Shellfish-Free",
					"Pork-Free",
					"Red-Meat-Free",
					"Crustacean-Free",
					"Celery-Free",
					"Mustard-Free",
					"Sesame-Free",
					"Lupine-Free",
					"Mollusk-Free",
					"Alcohol-Free",
					"No oil Added",
					"Kosher",
					"FODMAP-Free",
					"Mediterranean",
					"Sulfite-Free",
					"Immuno-Supportive",
					"Low Potassium",
					"Kidney-Friendly",
					"Sugar-Conscious",
					"Keto-Friendly",
					"Paleo",
					"DASH",
				},
				DietLabels = new List<string>()
				{
					"Low-Fat",
					"Low-Sodium",
					"Balanced",
					"Low-Carb",
					"High-Fiber"
				},
				Cautions = new List<string>()
				{
					"Sulfites",
					"FODMAP",
					"Gluten",
					"Wheat",
					"Soy",
					"Tree-Nuts",
				},
				CuisineType = new List<string>()
				{
					"american",
					"indian",
					"british",
					"mediterranean",
					"french",
					"nordic",
					"mexican",
					"italian"
				};
	}
}
