using MediatR;
using Organi.Application.Features.ProductNutritions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Queries
{
    public class GetAllProductNutritionsQuery : IRequest<List<ResultProductNutritionDto>>
    {
    }
}
