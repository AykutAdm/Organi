using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Domain.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetAllAsync();
        Task<Basket> GetByIdAsync(int id);
        Task AddAsync(Basket basket);
        Task UpdateAsync(Basket basket);
        Task DeleteAsync(Basket basket);
        Task<int> BasketItemCountAsync();
    }
}
