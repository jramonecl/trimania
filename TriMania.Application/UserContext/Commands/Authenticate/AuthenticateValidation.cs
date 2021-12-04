using FluentValidation;
using TriMania.Infra.FluentValidation;

namespace TriMania.Application.UserContext.Commands.Authenticate
{
    public class AuthenticateValidation : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidation()
        {
            RuleFor(n => n.Login).NaoNuloOuVazio();
            RuleFor(n => n.Password).NaoNuloOuVazio();
        }
    }
}