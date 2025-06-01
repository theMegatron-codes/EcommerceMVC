using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models
{
    public class Category
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

     // Navigations property(1 : Many)
        public ICollection<Product>? Products { get; set; }

    }
    
}
