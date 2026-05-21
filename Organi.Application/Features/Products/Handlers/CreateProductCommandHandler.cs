using AutoMapper;
using MediatR;
using Organi.Application.Features.Products.Chain.Handlers;
using Organi.Application.Features.Products.Commands;
using Organi.Application.Features.Products.Events;
using Organi.Domain.Entities;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var priceHandler = new PriceValidationHandler();
            var stockHandler = new StockValidationHandler();
            var nameHandler = new ProductNameValidationHandler();

            priceHandler.SetNext(stockHandler);

            stockHandler.SetNext(nameHandler);

            await priceHandler.Handle(product);


            await _unitOfWork.Products.AddAsync(product);

            await _unitOfWork.SaveChangesAsync();


            // Create Event - Trigger Observers
            await _mediator.Publish(new ProductAddedEvent(product), cancellationToken);
        }
    }
}
