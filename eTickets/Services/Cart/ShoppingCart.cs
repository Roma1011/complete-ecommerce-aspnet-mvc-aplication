using eTickets.Data;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services.Cart
{
    public class ShoppingCart: IShopingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShopipingCartItems { get; set; }
        public AppDbContext _context { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddItemToCart(Movie movie)
        {
            var shoppingCartItem = await
                _context.ShopipingCardItems.FirstOrDefaultAsync(n =>
                    n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShopipingCardItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems()
        {
            return ShopipingCartItems ?? (ShopipingCartItems = await _context.ShopipingCardItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToListAsync());
        }

        public async Task<double> GetShoppingCartTotal()
        {
            var total = await _context.ShopipingCardItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).SumAsync();

            return total;
        }

        public async Task RemoveItemToCart(Movie movie)
        {
            var shoppingCartItem = await
                _context.ShopipingCardItems.FirstOrDefaultAsync(n =>
                    n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShopipingCardItems.Remove(shoppingCartItem);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
