using AutoMapper;
using MediatR;
using Organi.Application.Features.ProductNutritions.DTOs;
using Organi.Application.Features.ProductNutritions.Queries;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Handlers
{
    public class GetProductNutritionByIdQueryHandler : IRequestHandler<GetProductNutritionByProductIdQuery, GetProductNutritionByIdDto>
    {
        private readonly IProductNutritionRepository _repository;
        private readonly IMapper _mapper;

        public GetProductNutritionByIdQueryHandler(IProductNutritionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductNutritionByIdDto> Handle(GetProductNutritionByProductIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByProductIdAsync(request.Id);
            return _mapper.Map<GetProductNutritionByIdDto>(value);
        }
    }
}
