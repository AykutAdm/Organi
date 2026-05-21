using AutoMapper;
using MediatR;
using Organi.Application.Features.Products.DTOs;
using Organi.Application.Features.Products.Queries;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class GetRecentProductsQueryHandler : IRequestHandler<GetRecentProductsQuery, List<RecentProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetRecentProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RecentProductDto>> Handle(GetRecentProductsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.RecentProducts();
            return _mapper.Map<List<RecentProductDto>>(values);
        }
    }
}
