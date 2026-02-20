using System;

namespace DesignPatternChallenge
{
    // Non-Terminal Expression: Comparação de Igualdade (A = B)
    public class EqualsExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public EqualsExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public object Interpret(Context context)
        {
            var leftValue = _left.Interpret(context);
            var rightValue = _right.Interpret(context);

            if (leftValue == null && rightValue == null) return true;
            if (leftValue == null || rightValue == null) return false;

            // Se for string, compara via Equals padrão (ignorando case por segurança se necessário)
            if (leftValue is string lStr && rightValue is string rStr)
            {
                return string.Equals(lStr, rStr, StringComparison.OrdinalIgnoreCase);
            }
            
            // Tratamento genérico de Equals para tipos primitivos
            return leftValue.Equals(rightValue);
        }
    }
}
