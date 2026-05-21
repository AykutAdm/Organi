using MediatR;
using Organi.Application.Features.Dashboard.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Dashboard.Queries
{
    public class GetCategoryDistributionQuery : IRequest<List<CategoryDistributionDto>>
    {
    }
}
