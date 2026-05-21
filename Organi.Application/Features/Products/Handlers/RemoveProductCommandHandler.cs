using MediatR;
using Organi.Application.Features.Products.Commands;
using Organi.Application.Features.Products.Events;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public RemoveProductCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Products.GetByIdAsync(request.Id);
            await _unitOfWork.Products.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
            await _mediator.Publish(new ProductRemovedEvent(value), cancellationToken);

        }
    }
}
