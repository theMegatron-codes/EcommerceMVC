namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public   string? Price { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
        

    }
}
