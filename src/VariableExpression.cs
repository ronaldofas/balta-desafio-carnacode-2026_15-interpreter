using System;

namespace DesignPatternChallenge
{
    // Terminal Expression: Lê valores dinamicamente do Contexto
    public class VariableExpression : IExpression
    {
        private readonly string _variableName;

        public VariableExpression(string variableName)
        {
            _variableName = variableName;
        }

        public object Interpret(Context context)
        {
            var cart = context.Cart;
            switch (_variableName.ToLower())
            {
                case "quantidade":
                    return (decimal)cart.ItemQuantity; // Cast para decimal para facilitar comparações
                case "valor":
                    return cart.TotalValue;
                case "categoria":
                    return cart.CustomerCategory;
                case "primeiracompra":
                    return cart.IsFirstPurchase;
                default:
                    throw new ArgumentException($"Variável desconhecida: {_variableName}");
            }
        }
    }
}
