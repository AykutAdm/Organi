using AutoMapper;
using MediatR;
using Organi.Application.Features.Testimonials.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Testimonials.Handlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Testimonials.GetByIdAsync(request.TestimonialId);
            _mapper.Map(request, value);
            await _unitOfWork.Testimonials.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
