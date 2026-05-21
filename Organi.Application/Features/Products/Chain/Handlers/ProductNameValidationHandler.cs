using Organi.Application.Features.Products.Chain.Abstract;
using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Handlers
{
    public class ProductNameValidationHandler : ProductHandler
    {
        public override async Task Handle(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new Exception("Product name required");
            }

            if (NextHandler != null)
            {
                await NextHandler.Handle(product);
            }
        }
    }
}
