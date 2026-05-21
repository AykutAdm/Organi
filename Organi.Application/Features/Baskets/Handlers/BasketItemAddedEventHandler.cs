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
    public class BasketItemAddedEventHandler : INotificationHandler<BasketItemAddedEvent>
    {
        private readonly IStockService _stockService;

        public BasketItemAddedEventHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task Handle(BasketItemAddedEvent notification, CancellationToken cancellationToken)
        {
            await _stockService.DecreaseStockAsync(notification.ProductId, notification.Quantity);
        }
    }
}
