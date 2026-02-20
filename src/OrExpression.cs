using System;

namespace DesignPatternChallenge
{
    // Non-Terminal Expression: OR Lógico (A OU B)
    public class OrExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public OrExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public object Interpret(Context context)
        {
            var leftValue = Convert.ToBoolean(_left.Interpret(context));
            // Avaliação de curto-circuito
            if (leftValue) return true;

            var rightValue = Convert.ToBoolean(_right.Interpret(context));
            return leftValue || rightValue;
        }
    }
}
