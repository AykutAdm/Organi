using MediatR;
using Organi.Application.Features.Testimonials.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Testimonials.Handlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTestimonialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Testimonials.GetByIdAsync(request.Id);
            await _unitOfWork.Testimonials.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
