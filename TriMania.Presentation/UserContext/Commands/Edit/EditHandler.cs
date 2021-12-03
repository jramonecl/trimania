using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trimania.Shared.Exceptions;
using TriMania.Application.Contracts;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Services;
using TriMania.Domain.User.Specs;

namespace TriMania.Application.UserContext.Commands.Edit
{
    public class EditHandler : IRequestHandler<EditCommand, int>
    {
        private readonly IHashService _hashService;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditHandler(IUserRepository userRepository, IAddressRepository addressRepository, IHashService hashService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SingleAsync(new GetById(request.Id));

            if (user == null)
            {
                throw new BusinessRuleException("Usuário não encontrado");
            }

            user.Update(request.Name, _hashService.ComputeHash(request.Password), request.Email,
                request.Birthday);

            user.Address.Update(request.Address.Street, request.Address.Neighborhood, request.Address.Number,
                request.Address.City, request.Address.State);

            await _userRepository.UpdateAsync(user);
            await _addressRepository.UpdateAsync(user.Address);

            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}
