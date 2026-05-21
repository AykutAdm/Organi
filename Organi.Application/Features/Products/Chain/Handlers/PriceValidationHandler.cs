using Organi.Application.Features.Products.Chain.Abstract;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Handlers
{
    public class PriceValidationHandler : ProductHandler
    {
        public override async Task Handle(Product product)
        {
            if (product.Price <= 0)
            {
                throw new Exception("Price cannot be zero");
            }

            if (NextHandler != null)
            {
                await NextHandler.Handle(product);
            }
        }
    }
}
