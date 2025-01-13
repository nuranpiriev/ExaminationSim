using Examination.BL.Services.Abstractions;
using Examination.DAL.Contexts;
using Examination.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Services.Implementations;

public class CartItemService : ICartItemService
{
    private readonly AppDbContext _context;

    public CartItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateCartItemAsync(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(int id)
    {
        var item= await _context.CartItems.FindAsync(id);
        if(item == null)
        {
            throw new Exception("Item not found");
        }
        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<CartItem>> GetAllCartItemAsync()
    {
        return await _context.CartItems.ToListAsync();
    }

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null)
        {
            throw new Exception("Item not found");
        }
        return item;
    }

    public async Task UpdateCartItemAsync(int id, CartItem cartItem)
    {
       var editItem=await _context.CartItems.SingleOrDefaultAsync(x => x.Id == id);
        if (editItem == null)
        {
            throw new Exception("Item not found");
        };
        editItem = new()
        {
            Description = cartItem.Description,
            IconUrl = cartItem.IconUrl,
            ImageUrl = cartItem.ImageUrl,
            UpdatedAt = DateTime.Now,
            Title = cartItem.Title,

        };
        _context.CartItems.Update(editItem);
        await _context.SaveChangesAsync();
        
    }
}
