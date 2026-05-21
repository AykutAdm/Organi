using MediatR;

namespace Organi.Application.Features.Abouts.Commands
{
    public class RemoveAboutCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAboutCommand(int id)
        {
            Id = id;
        }
    }
}
