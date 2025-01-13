using Examination.BL.Services.Abstractions;
using Examination.DAL.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examination.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class CartItemController : Controller
{
    private readonly ICartItemService _cartItemService;

    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    public async Task<IActionResult> Index()
    {
        var items= await _cartItemService.GetAllCartItemAsync();
        return View(items);
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _cartItemService.DeleteCartItemAsync(id);
        return RedirectToAction("Index", "CartItem");
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CartItem cartItem)
    {
        CartItem newCartItem = new()
        {
            CreatedAt = DateTime.Now,
            Title = cartItem.Title,
            Description = cartItem.Description,
            ImageUrl = cartItem.ImageUrl,
            IconUrl = cartItem.IconUrl,
        };
        await _cartItemService.CreateCartItemAsync(newCartItem);

        return RedirectToAction("Index", "CartItem");
    }
    public IActionResult Update() { return View(); }

    [HttpPut]
    public async Task<IActionResult> Update(int id, CartItem cartItem)
    {
        CartItem editCartItem = new()
        {
            CreatedAt = cartItem.CreatedAt,
            Title = cartItem.Title,
            Description = cartItem.Description,
            ImageUrl = cartItem.ImageUrl,
            IconUrl = cartItem.IconUrl,
            UpdatedAt = cartItem.UpdatedAt,
            DeletedAt = cartItem.DeletedAt,
            IsDeleted = cartItem.IsDeleted
        };
        await _cartItemService.UpdateCartItemAsync(id, cartItem);
        return RedirectToAction("Index", "CartItem");

    }
}
