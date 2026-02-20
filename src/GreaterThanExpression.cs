using System;

namespace DesignPatternChallenge
{
    // Non-Terminal Expression: Operador Maior Que (A > B)
    public class GreaterThanExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public GreaterThanExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public object Interpret(Context context)
        {
            var leftValue = Convert.ToDecimal(_left.Interpret(context));
            var rightValue = Convert.ToDecimal(_right.Interpret(context));

            return leftValue > rightValue;
        }
    }
}
