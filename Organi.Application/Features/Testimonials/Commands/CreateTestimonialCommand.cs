using MediatR;

namespace Organi.Application.Features.Testimonials.Commands
{
    public class CreateTestimonialCommand : IRequest
    {
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
