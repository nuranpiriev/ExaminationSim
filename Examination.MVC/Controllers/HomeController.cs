using Examination.BL.Services.Abstractions;
using Examination.DAL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examination.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public HomeController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        public async Task<IActionResult> Index()
        {
           ICollection<CartItem> items = await _cartItemService.GetAllCartItemAsync();
            return View(items);
        }
    }
}
