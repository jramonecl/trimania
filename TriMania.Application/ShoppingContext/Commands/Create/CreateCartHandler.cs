using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TriMania.Application.Contracts;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.User.Repositories;

namespace TriMania.Application.ShoppingContext.Create
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCartHandler(IUserRepository userRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var activeOrder = await _orderRepository.GetActiveOrder(request.UserId);

            if (activeOrder != null)
            {
                return activeOrder.Id;
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);

            var order = Order.CreateNew(user.Id);

            await _orderRepository.InsertAsync(order);

            await _unitOfWork.CommitAsync();

            return order.Id;
        }
    }
}