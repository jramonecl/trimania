using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Services;

namespace TriMania.Application.UserContext.Commands.Authenticate
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, string>
    {
        private readonly IHashService _hashService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticateHandler(IMapper mapper, IUserRepository userRepository, IHashService hashService,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ByLoginAsync(request.Login);

            if (user == null)
            {
                throw new BusinessRuleException("Usuário não encontrado");
            }

            return user.Password == _hashService.ComputeHash(request.Password) ? _tokenService.GenerateToken(user) : throw new ApplicationException("Usuário não encontrado");
        }
    }
}