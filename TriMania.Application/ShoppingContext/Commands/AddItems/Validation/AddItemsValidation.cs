using FluentValidation;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class AddItemsValidation : AbstractValidator<AddItemsCommand>
    {
        public AddItemsValidation()
        {
            RuleForEach(n => n.Items).SetValidator(new ItemsValidation());
        }
    }
}