using AutoMapper;
using MediatR;
using Organi.Application.Features.Products.Chain.Abstract;
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
        private readonly IValidationChainFactory _validationChainFactory;

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IMediator mediator,
            IValidationChainFactory validationChainFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
            _validationChainFactory = validationChainFactory;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            // Chain of Responsibility ile validation
            var validationChain = _validationChainFactory.CreateProductValidationChain();
            await validationChain.Handle(product);

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            // Observer Pattern ile event trigger
            await _mediator.Publish(new ProductAddedEvent(product), cancellationToken);
        }
    }
}
