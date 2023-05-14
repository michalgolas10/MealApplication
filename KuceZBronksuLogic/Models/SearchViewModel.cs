using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class SearchViewModel
	{
		[Required]
		public string? IngrediendsList { get; set; }
		[Required]
		public int? KcalAmount { get; set; }
		[Required]
		public IEnumerable<string>? ListOfMealType { get; set; }
		[Required]
		public IEnumerable<string>? ListOfEmptyMealType { get; set; }
	}
}