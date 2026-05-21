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
    public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, ResultDashboardStatsDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDashboardStatsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
        {
            return new ResultDashboardStatsDto
            {
                TotalProducts = await _unitOfWork.Products.ProductCountAsync(),
                TotalCategories = await _unitOfWork.Categories.CategoryCountAsync(),
                BasketItems = await _unitOfWork.Baskets.BasketItemCountAsync(),
                LowStockItems = await _unitOfWork.Products.LowStockCountAsync()
            };
        }
    }
}
