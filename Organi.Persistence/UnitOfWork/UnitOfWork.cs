using Organi.Domain.Interfaces;
using Organi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrganiDbContext _context;

        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IBasketRepository Baskets { get; }
        public ISliderRepository Sliders { get; }
        public IAboutRepository Abouts { get; }
        public ITestimonialRepository Testimonials { get; }
        public IProductNutritionRepository ProductNutritions { get; }

        public UnitOfWork(
            OrganiDbContext context,
            IProductRepository products,
            ICategoryRepository categories,
            IBasketRepository baskets,
            ISliderRepository sliders,
            IAboutRepository abouts,
            ITestimonialRepository testimonials,
            IProductNutritionRepository productNutritions)
        {
            _context = context;
            Products = products;
            Categories = categories;
            Baskets = baskets;
            Sliders = sliders;
            Abouts = abouts;
            Testimonials = testimonials;
            ProductNutritions = productNutritions;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
