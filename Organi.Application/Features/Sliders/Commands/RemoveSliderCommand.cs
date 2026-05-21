using MediatR;

namespace Organi.Application.Features.Sliders.Commands
{
    public class RemoveSliderCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSliderCommand(int id)
        {
            Id = id;
        }
    }
}
