namespace ParsingTree;

using System;

/// <summary>
/// Class representing the parse tree
/// </summary>
public class ParsingTree
{
    /// <summary>
    /// abstract nested class for dividing node into operators and operands for building a parse tree
    /// </summary>
    private abstract class Node
    {
        // Abstract method for counting each operator or operand
        public abstract float Count();

        // Abstract method for printing each operator or operand
        public abstract void Print();

        /// <summary>
        /// A class representing operands
        /// </summary>
        public class Operand : Node
        {
            public string Value;
            public Operand(string element)
            {
                Value = element;
            }

            // The operand class calculates the value for them and returns it
            public override float Count()
            {
                return float.Parse(Value);
            }

            // The operand class can print the values of operands
            public override void Print()
            {
                Console.Write(Value);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// A class representing operators
        /// </summary>
        public abstract class Operator : Node
        {
            // Each operator , unlike an operand, has a right and a left son
            public Node? LeftSon;
            public Node? RightSon;

            // There will be only 4 operators, so the value field does not make sense

            // Template for printing operators
            public void OperatorPrintTemplate(string symbol)
            {
                Console.Write("(");
                Console.Write(symbol);
                LeftSon?.Print();
                RightSon?.Print();
                Console.Write(")");
            }

            // A class representing the operator +
            public class Plus : Operator
            {
                public override float Count()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        throw new NullReferenceException();
                    }
                    return LeftSon.Count() + RightSon.Count();
                }

                public override void Print()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        return;
                    }
                    OperatorPrintTemplate("+");
                }
            }

            // A class representing the operator -
            public class Minus : Operator
            {
                public override float Count()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        throw new NullReferenceException();
                    }
                    return LeftSon.Count() - RightSon.Count();
                }

                public override void Print()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        return;
                    }
                    OperatorPrintTemplate("-");
                }
            }

            // A class representing the operator /
            public class Divide : Operator
            {
                public override float Count()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        throw new NullReferenceException();
                    }
                    return LeftSon.Count() / RightSon.Count();
                }

                public override void Print()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        return;
                    }
                    OperatorPrintTemplate("/");
                }
            }

            // A class representing the operator *
            public class Multiplication : Operator
            {
                public override float Count()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        throw new NullReferenceException();
                    }
                    return LeftSon.Count() * RightSon.Count();
                }

                public override void Print()
                {
                    if (LeftSon == null || RightSon == null)
                    {
                        return;
                    }
                    OperatorPrintTemplate("*");
                }
            }
        }
    }

    Node? treeRoot;

    /// <summary>
    /// Function for building a tree
    /// </summary>
    /// <param name="expression">The expression that needs to be calculated</param>
    public void BuildTree(string expression)
    {
        int index = 0;
        Node? root = null;
        treeRoot = PrivateBuildTree(expression, ref index, root);
    }

    // Auxiliary function for building a tree
    private Node? PrivateBuildTree(string expression, ref int index, Node? node)
    {
        if (index >= expression.Length)
        {
            return node;
        }

        // Skip the characters we don't need
        while (expression[index] == '(' || expression[index] == ')' || expression[index] == ' ' && index < expression.Length)
        {
            index++;
        }

        // The condition in order to avoid confusion, for example, with 4 -5 and 4 - 5
        if (index < expression.Length - 1 && !IsOperand(expression[index + 1]) && CharIsOperator(expression[index]))
        {
            InitializeNode(expression, ref index, ref node);
            return node;
        }

        // The number could be negative
        int newIndex = expression[index] == '-' ? index + 1 : index;
        string nodeValue = "";
        while (newIndex < expression.Length && IsOperand(expression[newIndex]))
        {
            nodeValue += expression[newIndex];
            newIndex++;
        }
        Node? newNode = null;

        //This unused variable x is needed in order to call the function,
        //and it is the operand that is initialized,
        //because the last character of the number cannot be an operator (the file is considered correct
        int x = nodeValue.Length - 1;
        if (expression[index] == '-')
        {
            InitializeNode("-" + nodeValue, ref x, ref newNode);
        }
        else
        {
            InitializeNode(nodeValue, ref x, ref newNode);
        }
        index = newIndex;
        return newNode;
    }

    // A function for initializing nodes depending on which operator or operator is a string
    private void InitializeNode(string expression, ref int index, ref Node? node)
    {
        switch (expression[index])
        {
            case '+':
            {
                node = new Node.Operator.Plus();
                index++;
                ((Node.Operator.Plus)node).LeftSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Plus)node).LeftSon);
                ((Node.Operator.Plus)node).RightSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Plus)node).RightSon);
                return;
            }
            case '-':
            {
                node = new Node.Operator.Minus();
                index++;
                ((Node.Operator.Minus)node).LeftSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Minus)node).LeftSon);
                ((Node.Operator.Minus)node).RightSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Minus)node).RightSon);
                return;
            }
            case '*':
            {
                node = new Node.Operator.Multiplication();
                index++;
                ((Node.Operator.Multiplication)node).LeftSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Multiplication)node).LeftSon);
                ((Node.Operator.Multiplication)node).RightSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Multiplication)node).RightSon);
                return;
            }
            case '/':
            {
                node = new Node.Operator.Divide();
                index++;
                ((Node.Operator.Divide)node).LeftSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Divide)node).LeftSon);
                ((Node.Operator.Divide)node).RightSon = PrivateBuildTree(expression, ref index, ((Node.Operator.Divide)node).RightSon);
                return;
            }
            default:
            {
                node = new Node.Operand(expression);
                index++;
                return;
            }
        }
    }

    /// <summary>
    /// Function for printing a tree
    /// </summary>
    public void Print() => treeRoot?.Print();

    /// <summary>
    /// Function for calculating the value of an expression
    /// </summary>
    /// <returns>value of an expression</returns>
    public float Count()
    {
        if (treeRoot == null)
        {
            throw new NullReferenceException();
        }
        return treeRoot.Count();
    }

    private static bool CharIsOperator(char element) => element == '+' || element == '-' || element == '*' || element == '/';

    private static bool IsOperand(char element) => element <= '9' && element >= '0';
}
