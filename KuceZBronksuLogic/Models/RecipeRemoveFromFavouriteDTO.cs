﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Models
{
    internal class RecipeRemoveFromFavouriteDTO
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public DateTime DateWhenClicked { get; set; }
        public string? LabelOfRecie { get; set; }
    }
}
