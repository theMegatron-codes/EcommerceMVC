using Ecommerce.Models;
using Ecommerce.Data;

namespace Ecommerce.Data.Seeders
{
    public static class DbSeeder
    {
        public static void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Electronics" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Books" },
                    new Category { Name = "Home Appliances" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
    }
}
