namespace KuceZBronksuBLL.Models
{
	public class VisitedRecipesDTO
	{
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}