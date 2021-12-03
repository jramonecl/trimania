using Trimania.Shared.Exceptions;

namespace TriMania.Domain.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected async void CheckRule(IBusinessRule rule)
        {
            if (await rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
}