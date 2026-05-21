using MediatR;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Events
{
    public class ProductRemovedEvent : INotification
    {
        public Product Product { get; }

        public ProductRemovedEvent(Product product)
        {
            Product = product;
        }
    }
}
