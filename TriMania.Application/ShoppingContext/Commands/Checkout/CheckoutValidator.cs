using FluentValidation;

namespace TriMania.Application.ShoppingContext.Checkout
{
    public class CheckoutValidator : AbstractValidator<CheckoutCommand>
    {
        public CheckoutValidator()
        {
            RuleFor(n => n.Status).IsInEnum();
        }
    }
}