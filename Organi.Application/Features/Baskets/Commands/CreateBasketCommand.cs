using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Commands
{
    public class CreateBasketCommand : IRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
