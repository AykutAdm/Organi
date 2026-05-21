using MediatR;

namespace Organi.Application.Features.Abouts.Commands
{
    public class CreateAboutCommand : IRequest
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
