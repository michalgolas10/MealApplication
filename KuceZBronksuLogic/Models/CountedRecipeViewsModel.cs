using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Models
{
    public class CountedRecipeViewsModel
    {
        public int RecipeId { get; set; }
        public int Count { get; set; }
        public string? LabelOfRecipe { get; set; }
    }
}
