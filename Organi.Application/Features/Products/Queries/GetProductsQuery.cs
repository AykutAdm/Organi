using MediatR;
using Organi.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ResultProductDto>>
    {
    }
}
