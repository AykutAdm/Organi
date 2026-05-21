using Organi.Application.Features.Products.Chain.Abstract;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Handlers
{
    public class StockValidationHandler : ProductHandler
    {
        public override async Task Handle(Product product)
        {
            if (product.Stock < 0)
            {
                throw new Exception("Stock cannot be negative");
            }

            if (NextHandler != null)
            {
                await NextHandler.Handle(product);
            }
        }
    }
}
