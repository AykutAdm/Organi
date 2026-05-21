using MediatR;
using Organi.Application.Features.Products.Events;
using Organi.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class ProductRemovedStockHandler : INotificationHandler<ProductRemovedEvent>
    {
        private readonly IStockService _stockService;

        public ProductRemovedStockHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task Handle(ProductRemovedEvent notification, CancellationToken cancellationToken)
        {
            await _stockService.ClearStockAsync(notification.Product.ProductId);
        }
    }
}
