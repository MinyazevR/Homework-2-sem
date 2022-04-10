namespace StackCalculator;

using Stack;

/// <summary>
/// A class representing a stack calculator
/// </summary>
public class Calculator
{
    /// <summary>
    /// Function for counting expressions in postfix form
    /// </summary>
    /// <returns>Expression value</returns>
    public float CountTheExpressionInPostfixForm(string[] inputString, IStack<float> stack)
    {
        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] == "")
            {
                continue;
            }
            int number = 0;
            if (int.TryParse(inputString[i], out number))
            {
                stack.Push(number);
                continue;
            }
            if (stack.NumberOfElements() < 2)
            {
                throw new IncorrectExpressionException("");
            }
            float secondNumber = 0;
            float firstNumber = 0;
            try
            {
                secondNumber = stack.Pop();
                firstNumber = stack.Pop();
            }
            catch (StackException)
            {
                throw;
            }
            if (inputString[i] == "+")
            {
                stack.Push(firstNumber +  secondNumber);
                continue;
            }
            if (inputString[i] == "-")
            {
                stack.Push(firstNumber - secondNumber);
                continue;
            }
            if (inputString[i] == "*")
            {
                stack.Push(firstNumber * secondNumber);
                continue;
            }
            if (inputString[i] == "/")
            {
                if (Math.Abs(secondNumber - 0) < 0.0000000000000000000000000001)
                {
                    throw new DivideByZeroException("");
                }
                stack.Push(firstNumber / secondNumber);
            }
            else
            {
                throw new InvalidCharacterException("");
            }
        }
        if (stack.NumberOfElements() > 1)
        {
            throw new IncorrectExpressionException("");
        }
        if (stack.NumberOfElements() < 1)
        {
            throw new IncorrectExpressionException("");
        }
        return stack.Pop();
    }
}
