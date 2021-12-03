using FluentValidation;

namespace TriMania.Application.ShoppingContext.Create
{
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(n => n.UserId).GreaterThan(0).WithMessage("Usuário não encontrado");
        }
    }
}