using System;

using CalculationExpression;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please, input the expression");
        string? expression = Console.ReadLine();
        if(expression == null)
        {
            return;
        }
        CalculatExpression calculationExpression = new CalculatExpression();
        Console.WriteLine(calculationExpression.CountTheExpression(expression));
        calculationExpression.PrintExpression(expression);
        calculationExpression.DeleteExpression(expression);
    }
}
