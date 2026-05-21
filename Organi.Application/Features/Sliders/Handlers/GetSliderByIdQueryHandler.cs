using AutoMapper;
using MediatR;
using Organi.Application.Features.Sliders.DTOs;
using Organi.Application.Features.Sliders.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Sliders.Handlers
{
    public class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, GetSliderByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSliderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetSliderByIdDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Sliders.GetByIdAsync(request.Id);
            return _mapper.Map<GetSliderByIdDto>(value);
        }
    }
}
