using MediatR;
using Organi.Application.Features.Sliders.DTOs;

namespace Organi.Application.Features.Sliders.Queries
{
    public class GetSlidersQuery : IRequest<List<ResultSliderDto>>
    {
    }
}
