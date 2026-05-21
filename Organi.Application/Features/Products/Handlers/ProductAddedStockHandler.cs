using MediatR;
using Microsoft.Extensions.Logging;
using Organi.Application.Features.Products.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class ProductAddedStockHandler : INotificationHandler<ProductAddedEvent>
    {
        private readonly ILogger<ProductAddedStockHandler> _logger;

        public ProductAddedStockHandler(ILogger<ProductAddedStockHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Yeni ürün stoğa eklendi: {Name}, Başlangıç Stok: {Stock}", notification.Product.Name, notification.Product.Stock);
            return Task.CompletedTask;
        }
    }
}
