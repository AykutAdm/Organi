using AutoMapper;
using MediatR;
using Organi.Application.Features.Testimonials.DTOs;
using Organi.Application.Features.Testimonials.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Testimonials.Handlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTestimonialByIdDto> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Testimonials.GetByIdAsync(request.Id);
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }
    }
}
