using System;

namespace DesignPatternChallenge
{
    // Terminal Expression: Valor Fixo (10, "VIP", 0.15m)
    public class ConstantExpression : IExpression
    {
        private readonly object _value;

        public ConstantExpression(object value)
        {
            _value = value;
        }

        public object Interpret(Context context)
        {
            return _value;
        }
    }
}
