using Examination.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Services.Abstractions;

public interface ICartItemService
{
    Task<ICollection<CartItem>> GetAllCartItemAsync();
    Task<CartItem> GetCartItemByIdAsync(int id);
    Task CreateCartItemAsync(CartItem cartItem);
    Task UpdateCartItemAsync(int id,CartItem? cartItem);
    Task DeleteCartItemAsync(int id);
}
