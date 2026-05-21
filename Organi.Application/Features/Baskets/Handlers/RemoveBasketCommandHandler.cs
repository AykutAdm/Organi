using MediatR;
using Organi.Application.Features.Baskets.Commands;
using Organi.Application.Features.Baskets.Events;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Handlers
{
    public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public RemoveBasketCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(request.Id);

            await _unitOfWork.Baskets.DeleteAsync(basket);
            await _unitOfWork.SaveChangesAsync();

            // Observer tetikle Stok geri gelsin
            await _mediator.Publish(new BasketItemRemovedEvent(basket.ProductId, basket.Quantity), cancellationToken);
        }
    }
}
