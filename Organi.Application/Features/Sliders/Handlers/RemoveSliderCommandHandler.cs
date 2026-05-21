using MediatR;
using Organi.Application.Features.Sliders.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Sliders.Handlers
{
    public class RemoveSliderCommandHandler : IRequestHandler<RemoveSliderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveSliderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Sliders.GetByIdAsync(request.Id);
            await _unitOfWork.Sliders.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
