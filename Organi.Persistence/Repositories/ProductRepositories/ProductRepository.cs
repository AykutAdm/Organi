using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrganiDbContext _context;

        public ProductRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
            //return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithFilterAsync(int? categoryId, decimal? minPrice, decimal? maxPrice, string searchTerm)
        {
            var query = _context.Products.Include(x => x.Category).AsQueryable(); //Db de filtreleme

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query = query.Where(x => x.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(x => x.Price <= maxPrice);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearchTerm = searchTerm.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(lowerSearchTerm));
            }

            return await query.ToListAsync();
        }

        public async Task<int> LowStockCountAsync(int threshold = 30)
        {
            return await _context.Products.CountAsync(x => x.Stock < threshold);
        }

        public async Task<int> ProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<List<Product>> RecentProducts()
        {
            return await _context.Products.Include(x => x.Category).OrderByDescending(x => x.ProductId).Take(6).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
