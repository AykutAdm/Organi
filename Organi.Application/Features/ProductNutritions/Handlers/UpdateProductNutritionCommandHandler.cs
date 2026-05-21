using AutoMapper;
using MediatR;
using Organi.Application.Features.ProductNutritions.Commands;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Handlers
{
    public class UpdateProductNutritionCommandHandler : IRequestHandler<UpdateProductNutritionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductNutritionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductNutritionCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.ProductNutritions.GetByProductIdAsync(request.ProductId);
            _mapper.Map(request, value);
            await _unitOfWork.ProductNutritions.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
