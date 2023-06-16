using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class SearchViewModel
	{
		[Display(Name = "Ingredients")]
		public string? IngrediendsList { get; set; }

		[Display(Name = "Calories")]
		public int? KcalAmount { get; set; }

		[Required]
		public IEnumerable<string>? ListOfMealType { get; set; }

		[Display(Name = "MealType")]
		public IEnumerable<string>? ListOfEmptyMealType { get; set; }
	}
}