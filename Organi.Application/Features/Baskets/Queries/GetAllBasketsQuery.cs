using MediatR;
using Organi.Application.Features.Baskets.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Baskets.Queries
{
    public class GetAllBasketsQuery : IRequest<List<ResultBasketDto>>
    {
    }
}
