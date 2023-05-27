using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuAPIBLL.Models
{
	public class VisitedRecipeBO
	{
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}
