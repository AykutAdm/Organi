using AutoMapper;
using MediatR;
using Organi.Application.Features.Sliders.DTOs;
using Organi.Application.Features.Sliders.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Sliders.Handlers
{
    public class GetSlidersQueryHandler : IRequestHandler<GetSlidersQuery, List<ResultSliderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSlidersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultSliderDto>> Handle(GetSlidersQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Sliders.GetAllAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }
    }
}
