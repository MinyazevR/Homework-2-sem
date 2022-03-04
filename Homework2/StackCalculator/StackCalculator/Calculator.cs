using System;
using Stack;

namespace StackCalculator;

// A class representing a stack calculator
public class Calculator
{
    private StackOnLists<float> Stack = new StackOnLists<float>();

    // Function for counting expressions in postfix form
    public float CountTheExpressionInPostfixForm(string[] inputString)
    {
        int number = 0;
        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] == "")
            {
                continue;
            }
            if (int.TryParse(inputString[i], out number))
            {
                Stack.Push(number);
                continue;
            }
            float secondNumber = Stack.Pop();
            float firstNumber = Stack.Pop();
            if (inputString[i] == "+")
            {
                Stack.Push(firstNumber +  secondNumber);
                continue;
            }
            if (inputString[i] == "-")
            {
                Stack.Push(firstNumber - secondNumber);
                continue;
            }
            if (inputString[i] == "*")
            {
                Stack.Push(firstNumber * secondNumber);
                continue;
            }
            if (inputString[i] == "/")
            {
                if (secondNumber.CompareTo(0) == 0)
                {
                    throw new Exception("division by 0");
                }
                Stack.Push(firstNumber / secondNumber);
            }
            else
            {
                throw new Exception("Invalid character");
            }
        }
        if(Stack.ReturnNumberOfElements() != 1)
        {
            throw new Exception("Incorrect expression");
        }
        return Stack.Pop();
    }
    static void Main()
    {
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
