using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;

namespace Organi.Persistence.Repositories.SliderRepositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly OrganiDbContext _context;

        public SliderRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
        }

        public async Task DeleteAsync(Slider slider)
        {
            _context.Sliders.Remove(slider);
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            return await _context.Sliders.FindAsync(id);
        }

        public async Task UpdateAsync(Slider slider)
        {
            _context.Sliders.Update(slider);

        }
    }
}
