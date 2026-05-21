using AutoMapper;
using MediatR;
using Organi.Application.Features.Baskets.DTOs;
using Organi.Application.Features.Baskets.Queries;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Handlers
{
    public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQuery, List<ResultBasketDto>>
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBasketsQueryHandler(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultBasketDto>> Handle(GetAllBasketsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultBasketDto>>(values);
        }
    }
}
