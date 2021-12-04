using System;
using MediatR;

namespace TriMania.Application.UserContext.Commands.Register
{
    public class RegisterCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public RegisterAddressCommand Address { get; set; }
    }
}