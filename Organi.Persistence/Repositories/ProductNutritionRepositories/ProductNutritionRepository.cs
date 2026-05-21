using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.Repositories.ProductNutritionRepositories
{
    public class ProductNutritionRepository : IProductNutritionRepository
    {
        private readonly OrganiDbContext _context;

        public ProductNutritionRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductNutrition nutrition)
        {
            await _context.ProductNutritions.AddAsync(nutrition);
        }

        public async Task DeleteAsync(ProductNutrition nutrition)
        {
            _context.ProductNutritions.Remove(nutrition);
        }

        public async Task<List<ProductNutrition>> GetAllAsync()
        {
            return await _context.ProductNutritions.Include(x => x.Product).ToListAsync();
        }

        public async Task<ProductNutrition> GetByProductIdAsync(int productId)
        {
            return await _context.ProductNutritions.Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task UpdateAsync(ProductNutrition nutrition)
        {
            _context.ProductNutritions.Update(nutrition);
        }
    }
}
