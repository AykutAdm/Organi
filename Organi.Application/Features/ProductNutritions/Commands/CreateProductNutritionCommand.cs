using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Commands
{
    public class CreateProductNutritionCommand : IRequest
    {
        public int ProductId { get; set; }
        public string ServingSize { get; set; }
        public string Energy { get; set; }
        public string Fat { get; set; }
        public bool Carbohydrates { get; set; }
        public decimal Protein { get; set; }
        public string Note { get; set; }
    }
}
