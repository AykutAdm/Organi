using AutoMapper;
using MediatR;
using Organi.Application.Features.Abouts.Commands;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Abouts.Handlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAboutCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = _mapper.Map<About>(request);
            await _unitOfWork.Abouts.AddAsync(about);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
