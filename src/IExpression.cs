namespace DesignPatternChallenge
{
    // Interface abstrata que será implementada por 
    // todas as expressões terminais e não-terminais na Árvore de Sintaxe.
    public interface IExpression
    {
        // Retorna object pois a avaliação pode gerar um booleano (verdadeiro/falso),
        // um número (como 10) ou uma string (como "VIP").
        object Interpret(Context context);
    }
}
