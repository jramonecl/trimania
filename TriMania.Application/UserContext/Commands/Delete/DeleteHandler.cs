using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.User.Repositories;

namespace TriMania.Application.UserContext.Commands.Delete
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHandler(IMapper mapper, IUserRepository userRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var hasOrders = await _orderRepository.UserHasOrders(request.Id);

            if (hasOrders)
            {
                throw new BusinessRuleException("Existem pedido(s) associado(s) a este usuário");
            }

            var user = await _userRepository.GetByIdAsync(request.Id);

            await _userRepository.DeleteAsync(user);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}