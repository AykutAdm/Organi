using AutoMapper;
using MediatR;
using Organi.Application.Features.Abouts.DTOs;
using Organi.Application.Features.Abouts.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Abouts.Handlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAboutByIdDto> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Abouts.GetByIdAsync(request.Id);
            return _mapper.Map<GetAboutByIdDto>(value);
        }
    }
}
