using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.User.Repositories;
using Trimania.Shared.Exceptions;

namespace TriMania.Domain.User.Rules
{
    public class LoginMustBeUnique : IBusinessRule
    {
        private readonly IUserRepository _repository;
        private readonly string _login;

        internal LoginMustBeUnique(IUserRepository repository, string login)
        {
            _repository = repository;
            _login = login;
        }

        public async Task<bool> IsBroken() => (await _repository.ByLoginAsync(_login)) != null;

        public string Message => $"O Login: [ {_login} ] já está em uso";
    }
}
