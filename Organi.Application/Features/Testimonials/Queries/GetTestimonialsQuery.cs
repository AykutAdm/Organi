using MediatR;
using Organi.Application.Features.Testimonials.DTOs;

namespace Organi.Application.Features.Testimonials.Queries
{
    public class GetTestimonialsQuery : IRequest<List<ResultTestimonialDto>>
    {
    }
}
