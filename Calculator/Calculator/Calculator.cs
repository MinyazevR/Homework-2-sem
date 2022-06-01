namespace Calculator;

/// <summary>
/// Class representing Calculator
/// </summary>
public class Calculator
{
    private string? FirstOperand { get; set; }

    private string? SecondOperand { get; set; }

    private string? Operator { get; set; }

    private string? SecondOperator { get; set; }

    public string? Text { get; private set; }

    /// <summary>
    /// Is the string an operetor
    /// </summary>
    /// <param name="text">Input string</param>
    /// <returns>True if the string is an operator</returns>
    public static bool IsOperator(string text) => text == "/" || text == "*" || text == "-" || text == "+" || text == "±" || text == "=" || text == "√" || text == "C" || text == "⌫";

    public string? CalculateExpression(string[] expression)
    {
        for (int i = 0; i < expression.Length; i++)
        {
            if(!AddOperatorOrOperand(expression[i]))
            {
                GetValue();
            }
        }
        return FirstOperand;
    }

    /// <summary>
    /// A function for calculating an expression of the form operator operand operator
    /// </summary>
    /// <returns>The resulting value</returns>
    public string? GetValue()
    {
        if (FirstOperand == null || SecondOperand == null)
        {
            return FirstOperand;
        }

        float firstNumber = float.Parse(FirstOperand);
        float secondNumber = float.Parse(SecondOperand);
        switch (Operator)
        {
            case "+":
            {
                FirstOperand = (firstNumber + secondNumber).ToString();
                break;
            }
            case "-":
            {
                FirstOperand = (firstNumber - secondNumber).ToString();
                break;
            }
            case "*":
            {
                FirstOperand = (firstNumber * secondNumber).ToString();
                break;
            }
            case "/":
            {
                if (Math.Abs(secondNumber - 0) < 0.000000000000000000000000000001)
                {
                     FirstOperand = SecondOperand = Operator = SecondOperand = null;
                }
                break;
            }
            default:
            {
                return null;
            }
        }

        SecondOperand = null;
        Text = $"{FirstOperand} {SecondOperator} ";
        Operator = SecondOperator;
        return FirstOperand;
    }

    /// <summary>
    /// Function for initializing an operator or operand
    /// </summary>
    /// <param name="text"></param>
    public bool AddOperatorOrOperand(string text)
    {
        if (text == "")
        {
            return true;
        }

        if (!IsOperator(text))
        {
            if (text == ",")
            {
                if (Text!= null && Text.Contains(',') || FirstOperand == null)
                {
                    return true;
                }
            }
            if (Operator == null)
            {
                FirstOperand += text;
            }
            else
            {
                SecondOperand += text;
            }

            Text += text;
            return true;
        }

        if (FirstOperand == null)
        {
            return true;
        }

        switch (text)
        {
            case "±":
            {
                Text = GetValue();
                if (FirstOperand != null)
                {
                    FirstOperand = FirstOperand[0] == '-' ? FirstOperand[1..FirstOperand.Length] : $"-{FirstOperand[0..FirstOperand.Length]}";
                }

                Operator = null;
                Text = FirstOperand;
                return true;
            }

            case "√":
            {
                Text = GetValue();
                if (FirstOperand != null)
                {
                    FirstOperand = FirstOperand[0] == '-' ? null : Math.Sqrt(double.Parse(FirstOperand)).ToString();
                }

                Text = FirstOperand;
                return true;
            }

            case "⌫":
            {
                if (SecondOperand != null)
                {
                    if (SecondOperand.Length == 1)
                    {
                        SecondOperand = null;
                        Text = $"{FirstOperand} {Operator} ";
                    }

                    else
                    {
                        SecondOperand = SecondOperand[0..(SecondOperand.Length - 1)];
                        Text = $"{FirstOperand} {Operator} {SecondOperand}";
                    }
                }

                else if (Operator != null)
                {
                    Operator = null;
                    Text = $"{FirstOperand} ";
                }

                else if (FirstOperand != null)
                {
                    if (FirstOperand.Length == 1)
                    {
                        FirstOperand = null;
                        Text = "";
                    }

                    else
                    {
                        FirstOperand = FirstOperand[0..(FirstOperand.Length - 1)];
                        Text = $"{FirstOperand}";
                    }
                }

                return true;
            }

            case "C":
            {
                Text = FirstOperand = SecondOperand = Operator = SecondOperator = null;
                return false;
            }

            case "=":
            {
                Text = FirstOperand = GetValue();
                SecondOperand = Operator = SecondOperator = null;
                return true;
            }

            default:
            {
                Text += " " + text + " ";
                if (Operator != null)
                {
                    if (SecondOperand == null)
                    {
                        Operator = text;
                    }
                    SecondOperator = text;
                    return false;
                }
                Operator = text;
                return false;
            }
        }
    }
}


