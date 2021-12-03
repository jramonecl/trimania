using System;

namespace Trimania.Shared.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(IBusinessRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public BusinessRuleException(string Message)
            : base(Message)
        {
        }

        public IBusinessRule BrokenRule { get; }

        public string Details { get; }
    }
}