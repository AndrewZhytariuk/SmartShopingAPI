using SmartShoping.Domain.Models;
using System.Data.Entity;

namespace SmartShoping.BusinessLogic.Interfaces
{
	public interface IContextDB
	{
		DbSet<Category> Categorys {get;set;}
		DbSet<Product> Products { get; set; }
	}
}
