using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Events
{
    public class BasketItemRemovedEvent : INotification
    {
        public int ProductId { get; }
        public int Quantity { get; }

        public BasketItemRemovedEvent(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
