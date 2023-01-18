using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System.Collections.Generic;

namespace SmartShoping.BusinessLogic.StubServices
{
	public class StubProductService : IProductService
	{
		public Product Get(int id)
		{
			return new Product() { Id = id, CategoryId = id, Name = "Iphone", Price = 1200 };
		}

		public List<Product> GetAll()
		{
			List<Product> list = new List<Product>()
			{
				new Product(){ Id = 1, CategoryId = 1, Name = "Iphone", Price = 1200},
				new Product(){ Id = 1, CategoryId = 2, Name = "Samsung", Price = 920}
			};

			return list;
		}

		public void Add(Product product) { }

		public void Update(Product product) { }

		public List<Product> Search(string productName)
		{
			List<Product> list = new List<Product>()
			{
				new Product(){ Id = 1, CategoryId = 1, Name = productName, Price = 1200}
			};

			return list;
		}

		public void Delete(int id) { }
	}
}
