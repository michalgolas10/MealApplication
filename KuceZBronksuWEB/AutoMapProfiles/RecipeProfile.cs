using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuWEB.Models;
using System.Collections;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace KuceZBronksuDAL.AutoMapProfiles
{
    public class RecipeProfile : Profile
    {
        
            public RecipeProfile()
            {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<EditAndCreateViewModel, Recipe>()
                .ForMember(dest=> dest.Calories, opts=> opts.MapFrom(src=> Double.Parse(src.Calories, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.IngredientLines, opts => opts.MapFrom(src => src.IngredientLines.Split(',',StringSplitOptions.None).ToList()));
            CreateMap<EditAndCreateViewModel, RecipeViewModel>();
            CreateMap<RecipeViewModel,EditAndCreateViewModel>();
            CreateMap<RecipeViewModel, Recipe>();
        }
    }
        
}