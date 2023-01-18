using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System.Collections.Generic;

namespace SmartShoping.BusinessLogic.StubServices
{
	public class StubCategoryService : ICategoryService
	{
		public List<Category> GetAll()
		{
			List<Category> list = new List<Category>()
			{
				new Category(){Id = 1, Name = "Iphone"},
				new Category(){ Id = 2, Name = "Samsung" }
			};

			return list;
		}

		public Category Get(int id)
		{
			return new Category() { Id = id, Name = "Iphone" };
		}

		public void Add(Category category) { }

		public void Update(Category category) { }

		public List<Category> Search(string categoryName)
		{
			List<Category> list = new List<Category>()
			{
				new Category(){Id = 1, Name = "Iphone"}
			};

			return list;
		}

		public void Delete(int id) { }
	}
}
