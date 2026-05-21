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
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            await _unitOfWork.Categories.DeleteAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
