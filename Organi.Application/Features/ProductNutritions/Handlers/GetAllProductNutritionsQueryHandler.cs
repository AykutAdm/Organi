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
    public class GetAllProductNutritionsQueryHandler : IRequestHandler<GetAllProductNutritionsQuery, List<ResultProductNutritionDto>>
    {
        private readonly IProductNutritionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductNutritionsQueryHandler(IProductNutritionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultProductNutritionDto>> Handle(GetAllProductNutritionsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultProductNutritionDto>>(values);
        }
    }
}
