using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SmartShoping.BusinessLogic.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ContextDB _contextDB;

        public CategoryService(IContextDB contextDB)
        {
            _contextDB = (ContextDB)contextDB ?? throw new ArgumentNullException(nameof(contextDB));
        }

        public List<Category> GetAll()
        {
            return _contextDB.Categorys.ToList();
        }

        public Category Get(int id)
        {
            return _contextDB.Categorys.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Category category)
        {
            _contextDB.Categorys.Add(category);

            _contextDB.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            _contextDB.Categorys.AddOrUpdate(category);

            _contextDB.SaveChangesAsync();
        }

        public List<Category> Search(string categoryName)
        {
            return _contextDB.Categorys.Where(p => p.Name == categoryName).ToList();
        }

        public void Delete(int id)
        {
            var category = _contextDB.Categorys.Find(id);

            if (category != null)
            {
                _contextDB.Categorys.Remove(category);

                _contextDB.SaveChangesAsync();
            }
        }
    }
}
