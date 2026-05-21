using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Commands
{
    public class RemoveProductNutritionCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductNutritionCommand(int id)
        {
            Id = id;
        }
    }
}
