using KuceZBronksuDAL.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Models
{
	public class VisitedRecipe : Entity
	{
		public int RecipeId { get; set; }
		public DateTime DateWhenClicked { get; set; }
		public string? LabelOfRecipe { get; set; }
	}
}
