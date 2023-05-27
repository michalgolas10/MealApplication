using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
	public class RecipeAddedToFavourite : Entity
	{
		public int UserId { get; set; }
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}