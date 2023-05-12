using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.VisualBasic.FileIO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KuceZBronksuBLL.xUnitTests.ServicesTests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IRepository<Recipe>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IRecipeService> _recipeServiceMock

        public RecipeServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Recipe>>();
            _mapperMock = new Mock<IMapper>();
            _recipeServiceMock = new Mock<IRecipeService>();
        }

        [Fact]
        public async Task GetRecipe_ShouldReturnCorrectRecipeViewModel()
        {
            // Arrange
            var recipe = new Recipe() { Id = 1, Label = "Test Recipe 1", Calories = 524, Cautions = new List<string> { "Sulfites" }, IngredientLines = new List<string> { "Milk" } };
            var recipeViewModel = new RecipeViewModel() { Id = 1, Label = "Test Recipe 1", Calories = 524, Cautions = new List<string> { "Sulfites" }, IngredientLines = new List<string> { "Milk" } };
            _repositoryMock.Setup(repo => repo.Get(recipe.Id.Value)).ReturnsAsync(recipe);
            _mapperMock.Setup(mapper => mapper.Map<RecipeViewModel>(recipe)).Returns(recipeViewModel);

            // Act
            var result = await _recipeService.GetRecipe(recipe.Id.Value);

            // Assert
            Assert.Equal(recipeViewModel, result);
        }

        [Fact]
        public async Task GetAllRecipies_ShouldReturnCorrectRecipeViewModels()
        {
            // Arrange
            var recipes = new List<Recipe>()
                    {
                        new Recipe() { Id = 1, Label = "Test Recipe 1", Calories=524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Milk"}, Approved = true},
                        new Recipe() { Id = 2, Label = "Test Recipe 2", Calories=1524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Eggs"},Approved = true},
                        new Recipe() { Id = 3, Label = "Test Recipe 3", Calories=224, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Wheat"},Approved = true},
                    };
            var recipeViewModels = new List<RecipeViewModel>()
                    {
                        new RecipeViewModel() { Id = 1, Label = "Test Recipe 1", Calories=524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Milk"} ,Approved = true},
                        new RecipeViewModel() { Id = 2, Label = "Test Recipe 2", Calories=1524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Eggs"},Approved = true},
                        new RecipeViewModel() { Id = 3, Label = "Test Recipe 3", Calories=224, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Wheat"},Approved = true},
                    };
            var calls = 0;
            _repositoryMock.Setup(repo => repo.GetAll(default)).ReturnsAsync(recipes);
            _mapperMock.Setup(m => m.Map<RecipeViewModel>(It.IsAny<Recipe>()))
            .Returns(() => recipeViewModels[calls])
            .Callback(() => calls++);
            var result = await _recipeService.GetAllRecipies();
            // Assert
            Assert.Equal(recipeViewModels, result);
        }
        [Fact]
        public async Task GetAllRecipies_ShouldReturnCorrectRecipeViewModelsButWithotOne()
        {
            // Arrange
            var recipes = new List<Recipe>()
                    {
                        new Recipe() { Id = 1, Label = "Test Recipe 1", Calories=524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Milk"}, Approved = true},
                        new Recipe() { Id = 2, Label = "Test Recipe 2", Calories=1524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Eggs"},Approved = true},
                        new Recipe() { Id = 3, Label = "Test Recipe 3", Calories=224, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Wheat"},Approved = false},
                    };
            var recipeViewModelsMapped = new List<RecipeViewModel>()
                    {
                        new RecipeViewModel() { Id = 1, Label = "Test Recipe 1", Calories=524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Milk"} ,Approved = true},
                        new RecipeViewModel() { Id = 2, Label = "Test Recipe 2", Calories=1524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Eggs"},Approved = true},
                        new RecipeViewModel() { Id = 3, Label = "Test Recipe 3", Calories=224, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Wheat"},Approved = false},
                    };
            var recipeViewModels = new List<RecipeViewModel>()
                    {
                        new RecipeViewModel() { Id = 1, Label = "Test Recipe 1", Calories=524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Milk"} ,Approved = true},
                        new RecipeViewModel() { Id = 2, Label = "Test Recipe 2", Calories=1524, Cautions=new List<string>{"Sulfites" } , IngredientLines = new List<string>{"Eggs"},Approved = true},
                    };
            var calls = 0;
            _repositoryMock.Setup(repo => repo.GetAll(default)).ReturnsAsync(recipes);
            _mapperMock.Setup(m => m.Map<RecipeViewModel>(It.IsAny<Recipe>()))
            .Returns(() => recipeViewModelsMapped[calls]) // Return next productModel
            .Callback(() => calls++);
            var result = await _recipeService.GetAllRecipies();
            // Assert
            Assert.Equal(recipeViewModels.Count, result.Count);
        }

        [Fact]
        public async Task CreateSearchModelWithMealTypes_ShouldReturnCorrectSearchViewModel()
        {
            // Arrange
            var expectedModel = new SearchViewModel()
            {
                ListOfMealType = new List<string>()
                        {
                            "breakfast",
                            "lunch/dinner",
                            "teatime"
                        }
            };
            // Act
            var result = await _recipeService.CreateSearchModelWithMealTypes();

            // Assert
            Assert.Equivalent(expectedModel.ListOfMealType, result.ListOfMealType);
        }
        [Fact]
        public async Task ChangeApprovedOfRecipe_ShouldReturnModelWithChangedApprovedToTrue()
        {
            var recipe = new Recipe() { Id = 1, Label = "Test Recipe 1", Calories = 524, Cautions = new List<string> { "Sulfites" }, IngredientLines = new List<string> { "Milk" }, Approved = false };
            _repositoryMock.Setup(repo => repo.Get(recipe.Id.Value)).ReturnsAsync(recipe);
            await _recipeService.ChangeApprovedOfRecipe(recipe.Id.Value);
            var result = new Recipe() { Id = 1, Label = "Test Recipe 1", Calories = 524, Cautions = new List<string> { "Sulfites" }, IngredientLines = new List<string> { "Milk" }, Approved = true };
            Assert.Equivalent(recipe.Approved,result.Approved);
        }
    }
}
