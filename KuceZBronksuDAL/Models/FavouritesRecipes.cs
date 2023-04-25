using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
