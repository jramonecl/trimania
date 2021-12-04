using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Services;

namespace TriMania.Application.UserContext.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly IHashService _hashService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterHandler(IUserRepository userRepository, IHashService hashService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var byLogin = await _userRepository.ByLoginAsync(request.Login);
            
            if (byLogin != null)
            {
                throw new BusinessRuleException("Login já está em uso");
            }

            var user = User.CreateNew(request.Name, request.Login, _hashService.ComputeHash(request.Password),
                request.Cpf, request.Email, request.Birthday, request.Address.Street, request.Address.Neighborhood, request.Address.Number,
                request.Address.City, request.Address.State);

            await _userRepository.InsertAsync(user);

            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}