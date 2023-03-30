﻿using KuceZBronksuDAL.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public ICollection<Recipe> FavouritesRecipes { get; set; }
    }
}