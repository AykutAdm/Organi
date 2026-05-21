using MediatR;
using Organi.Application.Features.Abouts.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Abouts.Handlers
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAboutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Abouts.GetByIdAsync(request.Id);
            await _unitOfWork.Abouts.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
