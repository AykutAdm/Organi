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
    public class ProductRemovedEventHandler : INotificationHandler<ProductRemovedEvent>
    {
        private readonly ILogger<ProductRemovedEventHandler> _logger;

        public ProductRemovedEventHandler(ILogger<ProductRemovedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductRemovedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Ürün silindi: {ProductName}", notification.Product.Name);
            return Task.CompletedTask;
        }
    }
}
