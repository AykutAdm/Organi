using MediatR;
using Organi.Application.Features.Baskets.Events;
using Organi.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Handlers
{
    public class BasketItemRemovedEventHandler : INotificationHandler<BasketItemRemovedEvent>
    {
        private readonly IStockService _stockService;

        public BasketItemRemovedEventHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task Handle(BasketItemRemovedEvent notification, CancellationToken cancellationToken)
        {
            await _stockService.IncreaseStockAsync(notification.ProductId, notification.Quantity);
        }
    }
}
