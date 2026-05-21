using AutoMapper;
using MediatR;
using Organi.Application.Features.Testimonials.Commands;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Testimonials.Handlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTestimonialCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = _mapper.Map<Testimonial>(request);
            await _unitOfWork.Testimonials.AddAsync(testimonial);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
