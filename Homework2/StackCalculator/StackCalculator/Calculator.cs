using System;
using Stack;

namespace StackCalculator;

/// <summary>
/// A class representing a stack calculator
/// </summary>
public class Calculator
{
    private IStack<float> Stack = new StackOnLists<float>();

    /// <summary>
    /// Function for counting expressions in postfix form
    /// </summary>
    /// <returns>Expression value</returns>
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
            try
            {
                if (Stack.ReturnNumberOfElements() < 2)
                {
                    throw new IncorrectExpressionException("Incorrect expression");
                }
            }
            catch (IncorrectExpressionException exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}");
                throw;
            }
            float secondNumber = 0;
            float firstNumber = 0;
            try
            {
                secondNumber = Stack.Pop();
                firstNumber = Stack.Pop();
            }
            catch (StackException)
            {
                Console.WriteLine("Incorrect expression");
                throw;
            }
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
                try
                {
                    if (secondNumber.CompareTo(0) == 0)
                    {
                        throw new DivideByZeroException("division by 0");
                    }
                }
                catch (DivideByZeroException exception)
                {
                    Console.WriteLine($"Ошибка: {exception.Message}");
                    throw;
                }
                Stack.Push(firstNumber / secondNumber);
            }
            else
            {
                try
                {
                    throw new InvalidCharacterException("Invalid character");
                }
                catch(InvalidCharacterException exception)
                {
                    Console.WriteLine($"Ошибка: {exception.Message}");
                    throw;
                }
            }
        }
        try
        {
            if (Stack.ReturnNumberOfElements() > 1)
            {
                throw new IncorrectExpressionException("Incorrect expression");
            }
        }
        catch (IncorrectExpressionException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            throw;
        }
        try
        {
            if (Stack.ReturnNumberOfElements() < 1)
            {
                throw new IncorrectExpressionException("Empty string");
            }
        }
        catch (IncorrectExpressionException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            throw;
        }
        return Stack.Pop();
    }
}
