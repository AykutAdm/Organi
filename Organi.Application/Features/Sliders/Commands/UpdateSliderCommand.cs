using MediatR;

namespace Organi.Application.Features.Sliders.Commands
{
    public class UpdateSliderCommand : IRequest
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
