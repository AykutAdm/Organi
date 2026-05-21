using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<List<Product>> GetProductsWithFilterAsync(int? categoryId, decimal? minPrice, decimal? maxPrice, string searchTerm);
        Task<int> ProductCountAsync();
        Task<int> LowStockCountAsync(int threshold = 30);
        Task<List<Product>> RecentProducts();
        Task<List<Product>> GetProductsWithCategoryAsync();
    }
}
