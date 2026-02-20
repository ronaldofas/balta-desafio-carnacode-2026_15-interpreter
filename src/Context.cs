namespace DesignPatternChallenge
{
    // O Contexto armazena a base de dados ou informações
    // onde a gramática vai procurar estado.
    public class Context
    {
        public ShoppingCart Cart { get; }

        public Context(ShoppingCart cart)
        {
            Cart = cart;
        }
    }
}
