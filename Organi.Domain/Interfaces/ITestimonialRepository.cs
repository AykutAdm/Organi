using Organi.Domain.Entities;

namespace Organi.Domain.Interfaces
{
    public interface ITestimonialRepository
    {
        Task<List<Testimonial>> GetAllAsync();
        Task<Testimonial> GetByIdAsync(int id);
        Task AddAsync(Testimonial testimonial);
        Task UpdateAsync(Testimonial testimonial);
        Task DeleteAsync(Testimonial testimonial);
    }
}
