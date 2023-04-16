using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuDAL.AutoMapProfiles
{
    public class RecipeProfile : Profile
    {
        
            public RecipeProfile()
            {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Recipe, EditViewModel>();
            }
        
    }
}
