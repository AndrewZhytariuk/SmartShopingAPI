
using System.Collections;

namespace SmartShoping.Domain.Models
{
    public class Category : IIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }
	}
}
