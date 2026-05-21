using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;

namespace Organi.Persistence.Repositories.AboutRepositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly OrganiDbContext _context;

        public AboutRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(About about)
        {
            await _context.Abouts.AddAsync(about);
        }

        public async Task DeleteAsync(About about)
        {
            _context.Abouts.Remove(about);

        }

        public async Task<List<About>> GetAllAsync()
        {
            return await _context.Abouts.ToListAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _context.Abouts.FindAsync(id);
        }

        public async Task UpdateAsync(About about)
        {
            _context.Abouts.Update(about);

        }
    }
}
