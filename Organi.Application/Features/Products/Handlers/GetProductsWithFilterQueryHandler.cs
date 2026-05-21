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
    public class GetProductsWithFilterQueryHandler : IRequestHandler<GetProductsWithFilterQuery, List<ResultProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsWithFilterQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultProductDto>> Handle(GetProductsWithFilterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetProductsWithFilterAsync(request.CategoryId, request.MinPrice, request.MaxPrice, request.SearchTerm);

            return _mapper.Map<List<ResultProductDto>>(values);
        }
    }
}
