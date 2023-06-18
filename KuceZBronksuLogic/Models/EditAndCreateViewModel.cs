using Newtonsoft.Json.Serialization;
using SharpDX.DXGI;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class EditAndCreateViewModel
	{
		public int? Id { get; set; }
		[StringLength(100, MinimumLength = 2)]
        [Display(Name = "Label")]
        [Required(ErrorMessage ="Required")]
        public string Label { get; set; }

        [Display(Name = "Calories")]
        [StringLength(200, MinimumLength = 2), Required(ErrorMessage = "Required")]
		public string Calories { get; set; }

        [Display(Name = "Image")]
        [StringLength(300, MinimumLength = 2),Required(ErrorMessage = "Required")]
		public string Image { get; set; }

		[Display(Name = "Ingredients")]
        public List<string> IngredientLines { get; set; }

		[Display(Name = "RecipeSteps")]
		public string? RecipeSteps { get; set; }

		[Display(Name = "ShareAs"), StringLength(300, MinimumLength = 2)]
		public string? ShareAs { get; set; }

		[Display(Name = "MealType"), Required(ErrorMessage = "Required")]
		public List<string>? MealType { get; set; }

		[Display(Name = "HealthLabels"), Required(ErrorMessage = "Required")]
		public List<string>? HealthLabels { get; set; }

		[Display(Name = "DietLabels"), Required(ErrorMessage = "Required")]
		public List<string>? DietLabels { get; set; }

		[Display(Name = "Cautions"), Required(ErrorMessage = "Required")]
		public List<string>? Cautions { get; set; }

		[Display(Name = "Cuisine Type"), Required(ErrorMessage = "Required")]
		public List<string>? CuisineType { get; set; }

		[Display(Name = "Servings"), Required(ErrorMessage = "Required")]
		public int Servings { get; set; }
	}
}