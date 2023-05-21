using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Models
{
	public class RecipeActivity
	{
		public int RecipeId { get; set; }
		public DateTime Date { get; set; }
		public string UserId { get; set; }
		public string RecipeType { get; set; }
	}
}
