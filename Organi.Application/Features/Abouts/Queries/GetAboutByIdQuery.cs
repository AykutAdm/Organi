using MediatR;
using Organi.Application.Features.Abouts.DTOs;

namespace Organi.Application.Features.Abouts.Queries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdDto>
    {
        public int Id { get; set; }

        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
