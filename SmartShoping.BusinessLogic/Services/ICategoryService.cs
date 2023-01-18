using SmartShoping.Domain.Models;
using System.Collections.Generic;

namespace SmartShoping.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category Get(int id);
        void Add(Category category);
        void Update(Category category);
        List<Category> Search(string categoryName);
        void Delete(int id);
    }
}
