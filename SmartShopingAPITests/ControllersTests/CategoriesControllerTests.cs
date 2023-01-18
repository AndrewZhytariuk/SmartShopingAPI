using NUnit.Framework;
using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.BusinessLogic.StubServices;
using SmartShoping.Domain.Models;
using SmartShopingAPI.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace SmartShopingAPITests.ControllersTests
{
	[TestFixture]
	public class CategoriesControllerTests
	{

		private readonly ICategoryService categoryService = new StubCategoryService();

		[Test]
		public void GetAll_SelectCategories_ReturnAllCategories()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);

			//act
			IHttpActionResult actionResult = categoriesController.GetAll();
			var response = actionResult as OkNegotiatedContentResult<List<Category>>;

			//assert
			Assert.IsNotNull(response.Content);
		}

		[Test]
		public void Get_SelectCategories_ReturnCategorieOnId()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);

			//act
			IHttpActionResult actionResult = categoriesController.Get(1);
			var response = actionResult as OkNegotiatedContentResult<Category>;

			//assert
			Assert.AreEqual("Iphone", response.Content.Name);
		}

		[Test]
		public void Add_AddCategory_Void()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);

			//act
			IHttpActionResult actionResult = categoriesController.Add(new Category() { Id = 1, Name = "Name"});
		}

		[Test]
		public void Update_UpdateCategory_Void()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);

			//act
			IHttpActionResult actionResult = categoriesController.Update(new Category() { Id = 1, Name = "Name" });
		}

		[Test]
		public void Search_SearchCategory_ReturnElementSearch()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);
			Category category = new Category { Id = 1, Name = "Iphone" };

			//act
			IHttpActionResult actionResult = categoriesController.Search("Iphone");
			var response = actionResult as OkNegotiatedContentResult<List<Category>>;

			//assert
			CollectionAssert.Contains(response.Content, category);
		}

		[Test]
		public void Delete_DeleteCategory_Void()
		{
			//arrange
			CategoriesController categoriesController = new CategoriesController(categoryService);

			//act
			IHttpActionResult actionResult = categoriesController.Delete(1);
		}
	}
}
