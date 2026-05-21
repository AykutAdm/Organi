using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.Repositories.BasketRepositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly OrganiDbContext _context;

        public BasketRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
        }

        public async Task<int> BasketItemCountAsync()
        {
            return await _context.Baskets.CountAsync();
        }

        public async Task DeleteAsync(Basket basket)
        {
            _context.Baskets.Remove(basket);
        }

        public async Task<List<Basket>> GetAllAsync()
        {
            return await _context.Baskets.Include(x => x.Product).ToListAsync();
        }

        public async Task<Basket> GetByIdAsync(int id)
        {
            return await _context.Baskets.Include(x => x.Product).FirstOrDefaultAsync(x => x.BasketId == id);
        }

        public async Task UpdateAsync(Basket basket)
        {
            _context.Baskets.Update(basket);
        }
    }
}
