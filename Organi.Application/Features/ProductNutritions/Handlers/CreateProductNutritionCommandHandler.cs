using AutoMapper;
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
    public class CreateProductNutritionCommandHandler : IRequestHandler<CreateProductNutritionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductNutritionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateProductNutritionCommand request, CancellationToken cancellationToken)
        {
            var nutrition = _mapper.Map<ProductNutrition>(request);
            await _unitOfWork.ProductNutritions.AddAsync(nutrition);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
