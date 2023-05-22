using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class SearchViewModel
	{
		[Required]
        [DisplayName("Ingredients")]
        public string? IngrediendsList { get; set; }
		[Required]
        [DisplayName("Kcal Amount")]
        public int? KcalAmount { get; set; }
		[Required]
		public IEnumerable<string>? ListOfMealType { get; set; }
		[Required]
        [DisplayName("Meal Type")]
        public IEnumerable<string>? ListOfEmptyMealType { get; set; }
	}
}