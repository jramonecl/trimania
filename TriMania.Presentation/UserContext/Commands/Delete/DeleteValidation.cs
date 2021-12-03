using FluentValidation;

namespace TriMania.Application.UserContext.Commands.Delete
{
    public class DeleteValidation : AbstractValidator<DeleteCommand>
    {
        public DeleteValidation()
        {
            RuleFor(n => n.Id).GreaterThan(0).WithMessage("Usuário não encontrado");
        }
    }
}