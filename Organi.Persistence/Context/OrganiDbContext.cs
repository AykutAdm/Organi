using Microsoft.EntityFrameworkCore;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Persistence.Context
{
    public class OrganiDbContext : DbContext
    {
        public OrganiDbContext(DbContextOptions<OrganiDbContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ProductNutrition> ProductNutritions { get; set; }
    }
}
