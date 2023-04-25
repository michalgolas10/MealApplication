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
using System.Drawing;
using KuceZBronksuBLL.Services;
using System.Security.Cryptography;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Text.RegularExpressions;
using KuceZBronksuDAL.Models;
using Newtonsoft.Json.Linq;
using System.Drawing.Text;

namespace KuceZBronksuDAL.AutoMapProfiles
{
	public class RecipeProfile : Profile
	{
		public RecipeProfile()
		{
			CreateMap<Recipe, RecipeViewModel>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => Math.Round(src.Calories)))
				.ForMember(dest => dest.Id, opts => opts.MapFrom(src => Encrypt(src.Id)))
				.ReverseMap();
			CreateMap<EditAndCreateViewModel, Recipe>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => Double.Parse(src.Calories, CultureInfo.InvariantCulture)));
			CreateMap<EditAndCreateViewModel, RecipeViewModel>()
				.ReverseMap();
		}
		private static string Encrypt(string input)
		{
			return input;
		}
	}

}