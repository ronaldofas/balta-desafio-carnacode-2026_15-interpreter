using System;
using System.Collections.Generic;
using DesignPatternChallenge;

Console.WriteLine("=========================================");
Console.WriteLine("   Executando o Sistema Legacy original  ");
Console.WriteLine("=========================================\n");

// Executando o sistema antigo
ChallengeProgram.RunLegacy();

Console.WriteLine("\n=========================================");
Console.WriteLine(" Executando o Novo Sistema (Interpreter) ");
Console.WriteLine("=========================================\n");

// Massa de dados idêntica a original
var cart1 = new ShoppingCart
{
    TotalValue = 1500.00m,
    ItemQuantity = 15,
    CustomerCategory = "Regular",
    IsFirstPurchase = false
};

var cart2 = new ShoppingCart
{
    TotalValue = 500.00m,
    ItemQuantity = 5,
    CustomerCategory = "VIP",
    IsFirstPurchase = false
};

var cart3 = new ShoppingCart
{
    TotalValue = 200.00m,
    ItemQuantity = 2,
    CustomerCategory = "Regular",
    IsFirstPurchase = true
};

// ----------------------------------------------------------------------
// Montando a Árvore de Sintaxe Abstrata (AST) manualmente.
// (Em um ambiente real teríamos um Parser Lexico-Sintático 
// transformando string em AST, mas a essência do padrão é a AST final).
// ----------------------------------------------------------------------

// Regra 1: "quantidade>10 E valor>1000 ENTAO 15"
var rule1Condition = new AndExpression(
    new GreaterThanExpression(new VariableExpression("quantidade"), new ConstantExpression(10m)),
    new GreaterThanExpression(new VariableExpression("valor"), new ConstantExpression(1000m))
);
var rule1 = new DiscountRule("quantidade>10 E valor>1000", rule1Condition, 15m);

// Regra 2: "categoria=VIP ENTAO 20"
var rule2Condition = new EqualsExpression(new VariableExpression("categoria"), new ConstantExpression("VIP"));
var rule2 = new DiscountRule("categoria=VIP", rule2Condition, 20m);

// Regra 3: "primeiraCompra=true ENTAO 10"
var rule3Condition = new EqualsExpression(new VariableExpression("primeiraCompra"), new ConstantExpression(true));
var rule3 = new DiscountRule("primeiraCompra=true", rule3Condition, 10m);

var rules = new List<DiscountRule> { rule1, rule2, rule3 };

// Avaliação

var carts = new[] { cart1, cart2, cart3 };
int cartIndex = 1;

foreach (var cart in carts)
{
    Console.WriteLine($"\n=== Novas Regras - Carrinho {cartIndex} ===");
    var context = new Context(cart);
    foreach (var rule in rules)
    {
        rule.Evaluate(context);
    }
    cartIndex++;
}

Console.WriteLine("\n=========================================");
Console.WriteLine("  Avaliando Expressão Complexa com AST   ");
Console.WriteLine("=========================================\n");

// Expressão desejada original: "((quantidade > 10 OU valor > 500) E categoria = VIP)"
// Observe como o padrão Interpreter a converte de forma nativa e hierárquica.
var complexCondition = new AndExpression(
    new OrExpression(
        new GreaterThanExpression(new VariableExpression("quantidade"), new ConstantExpression(10m)),
        new GreaterThanExpression(new VariableExpression("valor"), new ConstantExpression(500m))
    ),
    new EqualsExpression(new VariableExpression("categoria"), new ConstantExpression("VIP"))
);

var complexRule = new DiscountRule("((quantidade > 10 OU valor > 500) E categoria = VIP)", complexCondition, 25m);

var cartComplex = new ShoppingCart
{
    TotalValue = 600.00m, // Maior que 500 (Ativa a porção OU)
    ItemQuantity = 5,
    CustomerCategory = "VIP", // VIP (Ativa a porção E)
    IsFirstPurchase = false
};

var contextComplex = new Context(cartComplex);
Console.WriteLine("--- Carrinho Complexo: Quantidade=5, Valor=600, Categoria=VIP ---");
complexRule.Evaluate(contextComplex);
