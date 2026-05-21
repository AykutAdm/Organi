using AutoMapper;
using MediatR;
using Organi.Application.Features.Products.Chain.Handlers;
using Organi.Application.Features.Products.Commands;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Products.GetByIdAsync(request.ProductId);

            _mapper.Map(request, value);


            var priceHandler = new PriceValidationHandler();

            var stockHandler = new StockValidationHandler();

            var nameHandler = new ProductNameValidationHandler();

            priceHandler.SetNext(stockHandler);

            stockHandler.SetNext(nameHandler);

            await priceHandler.Handle(value);

            await _unitOfWork.Products.UpdateAsync(value);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
