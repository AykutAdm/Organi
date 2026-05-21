using Organi.Domain.Entities;

namespace Organi.Domain.Interfaces
{
    public interface ISliderRepository
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task AddAsync(Slider slider);
        Task UpdateAsync(Slider slider);
        Task DeleteAsync(Slider slider);
    }
}
