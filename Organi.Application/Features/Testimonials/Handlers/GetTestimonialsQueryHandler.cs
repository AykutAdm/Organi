using AutoMapper;
using MediatR;
using Organi.Application.Features.Testimonials.DTOs;
using Organi.Application.Features.Testimonials.Queries;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Testimonials.Handlers
{
    public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialsQuery, List<ResultTestimonialDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestimonialsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultTestimonialDto>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Testimonials.GetAllAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }
    }
}
