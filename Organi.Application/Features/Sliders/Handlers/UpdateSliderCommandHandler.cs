using AutoMapper;
using MediatR;
using Organi.Application.Features.Sliders.Commands;
using Organi.Domain.Interfaces;

namespace Organi.Application.Features.Sliders.Handlers
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Sliders.GetByIdAsync(request.SliderId);
            _mapper.Map(request, value);
            await _unitOfWork.Sliders.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
