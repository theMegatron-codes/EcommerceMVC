using System.Security.Claims;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show all cart items
        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .ToListAsync();

            return View(cartItems);
        }

        // Add product to cart
        [HttpPost]
        public async Task<IActionResult> Add(int productId, int quantity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                // User is not logged in, redirect or handle accordingly
                return RedirectToAction("Login", "Account");
            }

            var existingItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var cartItem = new Cart
                {
                    ProductId = productId,
                    Quantity = quantity,
                    UserId = userId
                };
                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Remove item from cart
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.Carts.FindAsync(id);
            if (item != null)
            {
                _context.Carts.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
