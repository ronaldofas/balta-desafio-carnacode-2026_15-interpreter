using System;

namespace DesignPatternChallenge
{
    // Non-Terminal Expression: AND Lógico (A E B)
    public class AndExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public AndExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public object Interpret(Context context)
        {
            var leftValue = Convert.ToBoolean(_left.Interpret(context));
            // Avaliação de curto-circuito (se a esquerda for falsa, nem avalia a direita)
            if (!leftValue) return false;

            var rightValue = Convert.ToBoolean(_right.Interpret(context));
            return leftValue && rightValue;
        }
    }
}
