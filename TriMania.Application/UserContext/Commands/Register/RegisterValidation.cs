using FluentValidation;
using TriMania.Infra.FluentValidation;

namespace TriMania.Application.UserContext.Commands.Register
{
    public class RegisterValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Name).NaoNuloOuVazio().NaoSerMenorQue().NaoSerMaiorQue();

            RuleFor(x => x.Login).NaoNuloOuVazio().NaoSerMenorQue().NaoSerMaiorQue();

            RuleFor(x => x.Password).NaoNuloOuVazio().NaoSerMenorQue(8).NaoSerMaiorQue();

            RuleFor(x => x.Cpf).NaoNuloOuVazio().NaoSerMenorQue(11).NaoSerMaiorQue(11);

            RuleFor(x => x.Email).NaoNuloOuVazio().NaoSerMenorQue(5).NaoSerMaiorQue();

            RuleFor(x => x.Birthday).NaoNuloOuVazio();

            RuleFor(x => x.Address.Street).NaoNuloOuVazio();

            RuleFor(x => x.Address.Neighborhood).NaoNuloOuVazio();

            RuleFor(x => x.Address.City).NaoNuloOuVazio();

            RuleFor(x => x.Address.State).NaoNuloOuVazio();
        }
    }
}