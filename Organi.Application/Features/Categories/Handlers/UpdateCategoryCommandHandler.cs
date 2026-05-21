using AutoMapper;
using MediatR;
using Organi.Application.Features.Categories.Commands;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);

            _mapper.Map(request, value);

            await _unitOfWork.Categories.UpdateAsync(value);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
