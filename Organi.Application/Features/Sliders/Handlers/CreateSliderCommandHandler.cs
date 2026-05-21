using AutoMapper;
using MediatR;
using Organi.Application.Features.Sliders.Commands;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Sliders.Handlers
{
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSliderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = _mapper.Map<Slider>(request);
            await _unitOfWork.Sliders.AddAsync(slider);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
