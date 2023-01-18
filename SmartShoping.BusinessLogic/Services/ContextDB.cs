using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System;
using System.Data.Entity;
using System;
using System.Configuration;

namespace SmartShoping.BusinessLogic
{
	public class ContextDB : DbContext, IContextDB
	{
		public ContextDB()
			: base("data source=AZHYTARIUK;initial catalog=ShopDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;User ID=sa;Password=innovator")
		{
		}

		public virtual DbSet<Category> Categorys { get; set; }

		public virtual DbSet<Product> Products { get; set; }

	}
}