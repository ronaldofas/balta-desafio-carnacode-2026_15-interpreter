using System;

namespace DesignPatternChallenge
{
    // Classe para agrupar uma regra de negócio (Condição AST -> Resultado de Desconto)
    public class DiscountRule
    {
        public IExpression Condition { get; }
        public decimal DiscountPercentage { get; }
        public string RuleName { get; }

        public DiscountRule(string ruleName, IExpression condition, decimal discountPercentage)
        {
            RuleName = ruleName;
            Condition = condition;
            DiscountPercentage = discountPercentage;
        }

        // Avalia se o contexto atual satisfaz a condição da regra e retorna o desconto
        public decimal Evaluate(Context context)
        {
            Console.WriteLine($"Avaliando regra: {RuleName}");
            // Interpreta a árvore de sintaxe a partir do nó raiz (Condition) passando o Contexto
            var isMatch = Convert.ToBoolean(Condition.Interpret(context));
            
            if (isMatch)
            {
                Console.WriteLine($"✓ Regra aplicada: {DiscountPercentage}% desconto");
                return DiscountPercentage;
            }

            Console.WriteLine("✗ Regra não aplicável");
            return 0;
        }
    }
}
