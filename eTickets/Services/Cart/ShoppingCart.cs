using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace eTickets.Services.Cart
{
    public class ShoppingCart : IShopingCart
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        //public ShoppingCart GetShoppingCart()
        //{
        //    var session = _httpContextAccessor.HttpContext.Session;
        //    var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        //    session.SetString("CartId", cartId);

        //    return new ShoppingCart(_context, _httpContextAccessor) { ShoppingCartId = cartId };
        //}

        public async Task AddItemToCart(Movie movie)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = await _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToListAsync());
        }

        public async Task<double> GetShoppingCartTotal()
        {
            var total = await _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Movie.Price * n.Amount).SumAsync();

            return total;
        }

        public async Task RemoveItemToCart(Movie movie)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
