using MediatR;
using Organi.Application.Features.Baskets.Commands;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Handlers
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBasketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(request.BasketId);

            basket.Quantity = request.Quantity;

            await _unitOfWork.Baskets.UpdateAsync(basket);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
