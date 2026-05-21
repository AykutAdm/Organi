using AutoMapper;
using MediatR;
using Organi.Application.Features.Categories.DTOs;
using Organi.Application.Features.Categories.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Categories.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<ResultCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultCategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
    }
}
