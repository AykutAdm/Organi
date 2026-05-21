using Organi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Chain.Abstract
{
    public abstract class ProductHandler
    {
        protected ProductHandler NextHandler;

        public void SetNext(ProductHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract Task Handle(Product product);
    }
}
