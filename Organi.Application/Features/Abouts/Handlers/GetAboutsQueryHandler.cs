using AutoMapper;
using MediatR;
using Organi.Application.Features.Abouts.DTOs;
using Organi.Application.Features.Abouts.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Abouts.Handlers
{
    public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQuery, List<ResultAboutDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAboutsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultAboutDto>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Abouts.GetAllAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }
    }
}
