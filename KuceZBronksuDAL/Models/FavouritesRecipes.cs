namespace KuceZBronksuDAL.Models
{
	public class FavouritesRecipes
	{
		public string UserId { get; set; }
		public string RecipeId { get; set; }

		//relationships
		public Recipe Recipe { get; set; }

		public User User { get; set; }
	}
}