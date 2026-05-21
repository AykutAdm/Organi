using MediatR;

namespace Organi.Application.Features.Sliders.Commands
{
    public class CreateSliderCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
