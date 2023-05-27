using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class SearchViewModel
	{
		[DisplayName("Ingredients")]
		public string? IngrediendsList { get; set; }

		[DisplayName("Kcal Amount")]
		public int? KcalAmount { get; set; }

		[Required]
		public IEnumerable<string>? ListOfMealType { get; set; }

		[DisplayName("Meal Type")]
		public IEnumerable<string>? ListOfEmptyMealType { get; set; }
	}
}