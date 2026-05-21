using MediatR;
using Organi.Application.Features.Abouts.DTOs;

namespace Organi.Application.Features.Abouts.Queries
{
    public class GetAboutsQuery : IRequest<List<ResultAboutDto>>
    {
    }
}
