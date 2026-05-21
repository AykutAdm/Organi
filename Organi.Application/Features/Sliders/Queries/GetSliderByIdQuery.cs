using MediatR;
using Organi.Application.Features.Sliders.DTOs;

namespace Organi.Application.Features.Sliders.Queries
{
    public class GetSliderByIdQuery : IRequest<GetSliderByIdDto>
    {
        public int Id { get; set; }

        public GetSliderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
