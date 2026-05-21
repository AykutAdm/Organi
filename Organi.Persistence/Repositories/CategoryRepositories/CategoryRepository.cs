using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OrganiDbContext _context;

        public CategoryRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<int> CategoryCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
