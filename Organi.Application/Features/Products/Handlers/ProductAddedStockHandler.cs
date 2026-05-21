using MediatR;
using Microsoft.Extensions.Logging;
using Organi.Application.Features.Products.Events;
using Organi.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class ProductAddedStockHandler : INotificationHandler<ProductAddedEvent>
    {
        private readonly IStockService _stockService;

        public ProductAddedStockHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            await _stockService.InitializeStockAsync(notification.Product.ProductId, notification.Product.Stock);
        }
    }
}
