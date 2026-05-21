using MediatR;
using Organi.Application.Features.Dashboard.DTOs;
using Organi.Application.Features.Dashboard.Queries;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Dashboard.Handlers
{
    public class GetCategoryDistributionQueryHandler : IRequestHandler<GetCategoryDistributionQuery, List<CategoryDistributionDto>>
    {
        private readonly IProductRepository _repository;

        public GetCategoryDistributionQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDistributionDto>> Handle(GetCategoryDistributionQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProductsWithCategoryAsync();
            var total = products.Count;

            return products.GroupBy(x => x.Category.Name)
            .Select(g => new CategoryDistributionDto
            {
                CategoryName = g.Key,
                ProductCount = g.Count(),
                Percentage = Math.Round((decimal)g.Count() / total * 100, 1)
            })
            .OrderByDescending(x => x.ProductCount)
            .ToList();
        }
    }
}
