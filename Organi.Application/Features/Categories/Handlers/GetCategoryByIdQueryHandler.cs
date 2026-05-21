using AutoMapper;
using MediatR;
using Organi.Application.Features.Categories.DTOs;
using Organi.Application.Features.Categories.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            return _mapper.Map<GetCategoryByIdDto>(value);
        }
    }
}
