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
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateBasketCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);

            if (product.Stock < request.Quantity)
                throw new Exception("Yetersiz stok!");

            var basket = new Basket
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            await _unitOfWork.Baskets.AddAsync(basket);
            await _unitOfWork.SaveChangesAsync();

            // Observer tetikle Stok azalsın
            await _mediator.Publish(new BasketItemAddedEvent(request.ProductId, request.Quantity), cancellationToken);
        }
    }
}
