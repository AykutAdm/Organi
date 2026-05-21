using Microsoft.EntityFrameworkCore;
using Organi.Application.Features.Products.Commands;
using Organi.Application.Features.Products.Chain.Abstract;
using Organi.Application.Features.Products.Chain.Factories;
using Organi.Application.Interfaces.Services;
using Organi.Application.Mapping;
using Organi.Domain.Interfaces;
using Organi.Infrastructure.Services;
using Organi.Persistence.Context;
using Organi.Persistence.Repositories.AboutRepositories;
using Organi.Persistence.Repositories.BasketRepositories;
using Organi.Persistence.Repositories.CategoryRepositories;
using Organi.Persistence.Repositories.ProductNutritionRepositories;
using Organi.Persistence.Repositories.ProductRepositories;
using Organi.Persistence.Repositories.SliderRepositories;
using Organi.Persistence.Repositories.TestimonialRepositories;
using Organi.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrganiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(GeneralMappingProfile).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IProductNutritionRepository, ProductNutritionRepository>();

builder.Services.AddScoped<IStockService, StockService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Chain of Responsibility Factory
builder.Services.AddScoped<IValidationChainFactory, ValidationChainFactory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
