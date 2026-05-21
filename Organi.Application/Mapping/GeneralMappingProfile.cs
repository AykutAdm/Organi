using AutoMapper;
using Organi.Application.Features.Abouts.Commands;
using Organi.Application.Features.Abouts.DTOs;
using Organi.Application.Features.Baskets.DTOs;
using Organi.Application.Features.Categories.Commands;
using Organi.Application.Features.Categories.DTOs;
using Organi.Application.Features.ProductNutritions.Commands;
using Organi.Application.Features.ProductNutritions.DTOs;
using Organi.Application.Features.Products.Commands;
using Organi.Application.Features.Products.DTOs;
using Organi.Application.Features.Sliders.Commands;
using Organi.Application.Features.Sliders.DTOs;
using Organi.Application.Features.Testimonials.Commands;
using Organi.Application.Features.Testimonials.DTOs;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            //Product
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<Product, ResultProductDto>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, GetProductByIdDto>()
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, RecentProductDto>()
           .ForMember(dest => dest.CategoryName,
               opt => opt.MapFrom(src => src.Category.Name));

            //Category
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, GetCategoryByIdDto>();

            //Slider
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Slider, UpdateSliderCommand>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>();
            CreateMap<Slider, GetSliderByIdDto>();

            //About
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, ResultAboutDto>();
            CreateMap<About, GetAboutByIdDto>();

            //Testimonial
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>();
            CreateMap<Testimonial, GetTestimonialByIdDto>();

            //Basket
            CreateMap<Basket, ResultBasketDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductImageUrl,
                    opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.ProductPrice,
                    opt => opt.MapFrom(src => src.Product.Price));


            //ProductNutration
            CreateMap<ProductNutrition, ResultProductNutritionDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductImageUrl,
                    opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.ProductPrice,
                    opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<ProductNutrition, GetProductNutritionByIdDto>()
               .ForMember(dest => dest.ProductName,
                   opt => opt.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.ProductImageUrl,
                   opt => opt.MapFrom(src => src.Product.ImageUrl))
               .ForMember(dest => dest.ProductPrice,
                   opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<ProductNutrition, CreateProductNutritionCommand>().ReverseMap();
            CreateMap<ProductNutrition, UpdateProductNutritionCommand>().ReverseMap();
        }
    }
}
