using NUnit.Framework;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using SmartShopingAPI.Controllers;
using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.BusinessLogic.StubServices;
using SmartShoping.Domain.Models;

namespace SmartShopingAPITests.ControllersTests
{
	[TestFixture]
	internal class ProductsControllerTests
	{
		private readonly IProductService productService = new StubProductService();

		[Test]
		public void GetAll_SelectProducts_ReturnAllProducts()
		{
			//arrang
			ProductsController productsController = new ProductsController(productService);

			//act
			IHttpActionResult actionResult = productsController.GetAll();
			var response = actionResult as OkNegotiatedContentResult<List<Product>>;

			//assert
			Assert.IsNotNull(response.Content);
		}

		[Test]
		public void Get_SelectProducts_ReturnProductOnId()
		{
			//arrang
			ProductsController productsController = new ProductsController(productService);

			//act
			IHttpActionResult actionResult = productsController.Get(1);
			var response = actionResult as OkNegotiatedContentResult<Product>;

			//assert
			Assert.AreEqual("Iphone", response.Content.Name);
		}

		[Test]
		public void Add_AddProduct_Void()
		{
			//arrange
			ProductsController productsController = new ProductsController(productService);

			//act
			IHttpActionResult actionResult = productsController.Add(new Product() { Id = 1, CategoryId = 1, Name = "Iphone", Price = 1300 });
		}

		[Test]
		public void Update_UpdateProduct_Void()
		{
			//arrange
			ProductsController productsController = new ProductsController(productService);

			//act
			IHttpActionResult actionResult = productsController.Update(new Product() { Id = 1, CategoryId = 1, Name = "Samsung", Price = 560 });
		}

		[Test]
		public void Search_SearchProduct_ReturnElementProduct()
		{
			//arrange
			ProductsController productsController = new ProductsController(productService);
			Product product = new Product() { Id = 1, CategoryId = 2, Name = "Iphone", Price = 700 };

			//act
			IHttpActionResult actionResult = productsController.Search("Iphone");
			var response = actionResult as OkNegotiatedContentResult<List<Product>>;

			//assert
			CollectionAssert.Contains(response.Content, product);
		}

		[Test]
		public void Delete_DeleteProduct_Void()
		{
			//arrange
			ProductsController productsController = new ProductsController(productService);

			//act
			IHttpActionResult actionResult = productsController.Delete(1);
		}
	}
}
