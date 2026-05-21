using Organi.Application.Features.Products.Chain.Abstract;
using Organi.Application.Features.Products.Chain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Factories
{
    public class ValidationChainFactory : IValidationChainFactory
    {
        public ProductHandler CreateProductValidationChain()
        {
            var priceHandler = new PriceValidationHandler();
            var nameHandler = new ProductNameValidationHandler();
            var stockHandler = new StockValidationHandler();

            priceHandler.SetNext(nameHandler).SetNext(stockHandler);

            return priceHandler;
        }
    }
}