using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Migrations;

namespace SmartShoping.BusinessLogic.Services
{
    public class ProductService : ServiceBase, IProductService
    {

        private readonly ContextDB _contextDB;

        public ProductService(IContextDB contextDB)
        {
            _contextDB = (ContextDB)contextDB ?? throw new ArgumentNullException(nameof(contextDB));
        }

        public Product Get(int id)
        {
            return _contextDB.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return _contextDB.Products.ToList();
        }

        public void Add(Product product)
        {
            _contextDB.Products.Add(product);

            _contextDB.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _contextDB.Products.AddOrUpdate(product);

            _contextDB.SaveChangesAsync();
        }

        public List<Product> Search(string productName)
		{
            return _contextDB.Products.Where(p => p.Name == productName).ToList();
		}

        public void Delete(int id)
        {
            var products = _contextDB.Products.Find(id);

            if(products != null)
			{
                _contextDB.Products.Remove(products);

                _contextDB.SaveChangesAsync();
			}
        }
    }
}
