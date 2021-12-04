using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TriMania.Application.UserContext.Commands.Register;
using TriMania.Infra.FluentValidation;

namespace TriMania.Application.UserContext.Commands.Edit
{
    public class EditValidator : AbstractValidator<EditCommand>
    {
        public EditValidator()
        {
            RuleFor(x => x.Name).NaoNuloOuVazio().NaoSerMenorQue().NaoSerMaiorQue();

            RuleFor(x => x.Password).NaoNuloOuVazio().NaoSerMenorQue(8).NaoSerMaiorQue();

            RuleFor(x => x.Email).NaoNuloOuVazio().NaoSerMenorQue(5).NaoSerMaiorQue();

            RuleFor(x => x.Birthday).NaoNuloOuVazio();

            RuleFor(x => x.Address.Street).NaoNuloOuVazio();

            RuleFor(x => x.Address.Neighborhood).NaoNuloOuVazio();

            RuleFor(x => x.Address.City).NaoNuloOuVazio();

            RuleFor(x => x.Address.State).NaoNuloOuVazio();
        }
    }
}
