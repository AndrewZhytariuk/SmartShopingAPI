using SmartShoping.Domain.Models;
using System;
using System.Collections.Generic;

namespace SmartShoping.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(int id);
        void Add(Product product);
        void Update(Product product);
        List<Product> Search(string productName);
        void Delete(int id);
    }
}
