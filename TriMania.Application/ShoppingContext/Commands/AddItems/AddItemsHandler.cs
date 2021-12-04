using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Application.ShoppingContext.AddItems.Service;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class AddItemsHandler : IRequestHandler<AddItemsCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly IUnitOfWork _unitOfWork;

        public AddItemsHandler(IOrderRepository orderRepository, ICartService cartService, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDto> Handle(AddItemsCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetActiveOrder(request.UserId);

            if (order == null)
            {
                throw new BusinessRuleException("Necessário inicializar o pedido antes de inserir um item");
            }

            var hasChanged = false;

            foreach (var item in request.Items)
            {
                
                if (await _cartService.IsAbleToAddAsync(item, order))
                {
                    hasChanged = await _cartService.AddAsync(item, order);
                }

                if (await _cartService.IsAbleToUpdateAsync(item, order))
                {
                    hasChanged = await _cartService.UpdateAsync(item, order);
                }

                if (await _cartService.IsAbleToDeleteAsync(item, order)) 
                {
                    hasChanged = await _cartService.DeleteAsync(item, order);
                }
            }

            if (hasChanged)
            {
                order.SetStatus(OrderStatus.InProgress);
                await _orderRepository.UpdateAsync(order);

                await _unitOfWork.CommitAsync();
            }

            return new OrderDto(await _orderRepository.GetActiveOrder(request.UserId));
        }
    }
}