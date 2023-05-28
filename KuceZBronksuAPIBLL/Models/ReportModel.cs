using KuceZBronksuDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuAPIBLL.Models
{
	public class ReportModel
	{
		public IEnumerable<VisitedRecipeDTO>? RecipesVisited { get; set; }
		public IEnumerable<LastLoggedUsersDTO>? LoggedUsers { get; set; }
		public IEnumerable<RecipeAddedToFavouriteDTO>? RecipeAddedToFavourite { get; set; }
	}
}
