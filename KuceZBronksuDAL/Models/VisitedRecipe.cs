using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
	public class VisitedRecipe : Entity
	{
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}