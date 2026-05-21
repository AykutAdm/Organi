using Organi.Domain.Entities;

namespace Organi.Domain.Interfaces
{
    public interface IAboutRepository
    {
        Task<List<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        Task AddAsync(About about);
        Task UpdateAsync(About about);
        Task DeleteAsync(About about);
    }
}
