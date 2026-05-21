using MediatR;
using Organi.Application.Features.ProductNutritions.Commands;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.ProductNutritions.Handlers
{
    public class RemoveProductNutritionCommandHandler : IRequestHandler<RemoveProductNutritionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductNutritionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductNutritionCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.ProductNutritions.GetByProductIdAsync(request.Id);
            await _unitOfWork.ProductNutritions.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
