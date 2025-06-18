namespace Ecommerce.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public string? UserId { get; set; } // FK to Identity User
        public int ProductId { get; set; } // FK to Product

        public int Quantity { get; set; }

        // Navigation Properties
        public ApplicationUser? User { get; set; }

        public Product? Product { get; set; }
    }

}
