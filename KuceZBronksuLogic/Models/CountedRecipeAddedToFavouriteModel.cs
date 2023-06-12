using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Models
{
    public class CountedRecipeAddedToFavouriteModel
    {
        public int RecipeId { get; set; }
        public int FavouriteCount { get; set; }
        public string? LabelOfRecipe { get; set; }
    }
}
