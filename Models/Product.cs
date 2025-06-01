using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;   

namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public   string? Price { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public Category? Category { get; set; } 


    }
}
