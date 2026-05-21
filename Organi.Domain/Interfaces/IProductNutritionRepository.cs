using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Domain.Interfaces
{
    public interface IProductNutritionRepository
    {
        Task<List<ProductNutrition>> GetAllAsync();
        Task<ProductNutrition> GetByProductIdAsync(int productId);
        Task AddAsync(ProductNutrition nutrition);
        Task UpdateAsync(ProductNutrition nutrition);
        Task DeleteAsync(ProductNutrition nutrition);
    }
}
