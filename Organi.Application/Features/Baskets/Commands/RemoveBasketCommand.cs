using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Commands
{
    public class RemoveBasketCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveBasketCommand(int id)
        {
            Id = id;
        }
    }
}
