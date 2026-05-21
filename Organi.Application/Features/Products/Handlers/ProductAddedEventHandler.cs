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
    public class ProductAddedEventHandler : INotificationHandler<ProductAddedEvent>
    {
        private readonly ILogger<ProductAddedEventHandler> _logger;

        public ProductAddedEventHandler(ILogger<ProductAddedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Yeni ürün eklendi: {ProductName}, Fiyat: {Price}", notification.Product.Name, notification.Product.Price);

            return Task.CompletedTask;
        }
    }
}
