namespace StackCalculator;

public class Solution
{
    static void Main()
    {
        Console.WriteLine("Please, enter the expression");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            return;
        }
        var subs = inputString.Split(' ');
        Calculator stackCalculator = new Calculator();
        Console.WriteLine($"{stackCalculator.CountTheExpressionInPostfixForm(subs)}");
    }
}
