using eTickets.Data.ModelView;
using eTickets.Services.Cart;
using eTickets.Services.Movies;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IShopingCart _shoppingCartService;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCartService)
        {
            _moviesService= moviesService;
            _shoppingCartService = shoppingCartService;
        }
        public async Task<IActionResult> Index()
        {
            var items =await _shoppingCartService.GetShoppingCartItems();
            _shoppingCartService.ShopipingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = (ShoppingCart)_shoppingCartService,
                ShoppingCartTotal =await _shoppingCartService.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}
