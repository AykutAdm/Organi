using AutoMapper;
using MediatR;
using Organi.Application.Features.Abouts.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Abouts.Handlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Abouts.GetByIdAsync(request.AboutId);
            _mapper.Map(request, value);
            await _unitOfWork.Abouts.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
