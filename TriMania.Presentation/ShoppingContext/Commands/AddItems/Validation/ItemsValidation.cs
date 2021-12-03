using FluentValidation;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class ItemsValidation : AbstractValidator<AddItemsProductCommand>
    {
        public ItemsValidation()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Produto não encontrado");
            RuleFor(n => n.Quantity).GreaterThan(0).WithMessage("Quantidade Inválida");
        }
    }
}