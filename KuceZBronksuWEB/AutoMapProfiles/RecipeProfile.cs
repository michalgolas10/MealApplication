using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuWEB.Models;
using System.Collections;

namespace KuceZBronksuDAL.AutoMapProfiles
{
    public class RecipeProfile : Profile
    {
        
            public RecipeProfile()
            {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<EditViewModel, Recipe>()
                .ForMember(x => x.Calories, opt => opt.Ignore())
                .ForMember(dest => dest.IngredientLines, opts => opts.MapFrom(src => src.IngredientLines.Split(',',StringSplitOptions.None).ToList()));
        }
    }
        
}
