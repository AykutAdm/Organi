using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IBasketRepository Baskets { get; }
        ISliderRepository Sliders { get; }
        IAboutRepository Abouts { get; }
        ITestimonialRepository Testimonials { get; }
        IProductNutritionRepository ProductNutritions { get; }
    }
}
