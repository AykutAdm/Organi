using MediatR;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Events
{
    public class ProductAddedEvent : INotification
    {
        public Product Product { get; }

        public ProductAddedEvent(Product product)
        {
            Product = product;
        }
    }
}
