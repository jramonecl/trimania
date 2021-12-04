using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;

namespace TriMania.Application.ShoppingContext.Checkout
{
    public class CheckoutHandler : IRequestHandler<CheckoutCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            order.Checkout(request.Status);

            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}