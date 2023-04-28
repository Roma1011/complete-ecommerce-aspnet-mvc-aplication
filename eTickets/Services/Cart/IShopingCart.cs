using eTickets.Models;

namespace eTickets.Services.Cart
{
    public interface IShopingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public Task AddItemToCart(Movie movie);
        public Task<List<ShoppingCartItem>> GetShoppingCartItems();
        public Task<double> GetShoppingCartTotal();
        public Task RemoveItemToCart(Movie movie);


    }
}
