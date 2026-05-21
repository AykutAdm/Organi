using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using Organi.Persistence.Context;

namespace Organi.Persistence.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly OrganiDbContext _context;

        public TestimonialRepository(OrganiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Testimonial testimonial)
        {
            await _context.Testimonials.AddAsync(testimonial);
        }

        public async Task DeleteAsync(Testimonial testimonial)
        {
            _context.Testimonials.Remove(testimonial);
        }

        public async Task<List<Testimonial>> GetAllAsync()
        {
            return await _context.Testimonials.ToListAsync();
        }

        public async Task<Testimonial> GetByIdAsync(int id)
        {
            return await _context.Testimonials.FindAsync(id);
        }

        public async Task UpdateAsync(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
        }
    }
}
