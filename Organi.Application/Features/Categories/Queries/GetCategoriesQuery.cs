using MediatR;
using Organi.Application.Features.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<List<ResultCategoryDto>>
    {
    }
}
