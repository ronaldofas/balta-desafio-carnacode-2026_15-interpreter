using System;

namespace DesignPatternChallenge
{
    // Non-Terminal Expression: NOT Lógico (NÃO A)
    public class NotExpression : IExpression
    {
        private readonly IExpression _expression;

        public NotExpression(IExpression expression)
        {
            _expression = expression;
        }

        public object Interpret(Context context)
        {
            var value = Convert.ToBoolean(_expression.Interpret(context));
            return !value;
        }
    }
}
