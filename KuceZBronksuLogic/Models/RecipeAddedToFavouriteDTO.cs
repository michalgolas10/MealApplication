namespace KuceZBronksuBLL.Models
{
	public class RecipeAddedToFavouriteDTO
	{
		public int UserId { get; set; }
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}