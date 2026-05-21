using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Abstract
{
    public interface IValidationChainFactory
    {
        ProductHandler CreateProductValidationChain();
    }
}