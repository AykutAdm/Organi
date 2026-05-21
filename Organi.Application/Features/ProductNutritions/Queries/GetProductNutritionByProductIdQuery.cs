using MediatR;
using Organi.Application.Features.ProductNutritions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Queries
{
    public class GetProductNutritionByProductIdQuery : IRequest<GetProductNutritionByIdDto>
    {
        public int Id { get; set; }

        public GetProductNutritionByProductIdQuery(int id)
        {
            Id = id;
        }
    }
}
