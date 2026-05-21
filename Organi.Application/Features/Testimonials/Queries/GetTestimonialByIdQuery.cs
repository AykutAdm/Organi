using MediatR;
using Organi.Application.Features.Testimonials.DTOs;

namespace Organi.Application.Features.Testimonials.Queries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdDto>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
