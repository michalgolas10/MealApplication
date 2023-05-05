﻿using KuceZBronksuDAL.Models.BaseEntity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
namespace KuceZBronksuDAL.Models
{
	public class User : IdentityUser, IEntity
    {
        int? IEntity.Id { get; set; }
        private readonly ILazyLoader _lazyLoader;
        public User()
        {
            
        }
        public User(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private List<Recipe> _recipes;
        public List<Recipe> Recipes
        {
            get => _lazyLoader.Load(this, ref _recipes);
            set => _recipes = value;
        }
    }
}