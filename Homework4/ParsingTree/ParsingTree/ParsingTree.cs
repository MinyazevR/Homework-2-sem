namespace ParsingTree;

using System;

/// <summary>
/// Class representing the parse tree
/// </summary>
public class ParsingTree
{
    private abstract class Node
    {
        /// <summary>
        /// Abstract method for counting each operator or operand
        /// </summary>
        /// <returns>Operator or operand value</returns>
        public abstract float Count();

        /// <summary>
        /// Abstract method for printing each operator or operand
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// A class representing operands
    /// </summary>
    private class Operand : Node
    {
        private readonly string Value;

        public Operand(string element)
        {
            Value = element;
        }

        /// <summary>
        ///  The operand class calculates the value for them and returns it
        /// </summary>
        /// <returns>Operand value</returns>
        public override float Count() => float.Parse(Value);

        /// <summary>
        /// The operand class can print the values of operands
        /// </summary>
        public override void Print()
        {
            Console.Write(Value);
            Console.Write(" ");
        }
    }

    /// <summary>
    /// A class representing operators
    /// </summary>
    private abstract class Operator : Node
    {
        public Node? LeftSon;
        public Node? RightSon;


        /// <summary>
        /// Void for printing operators
        /// </summary>
        public abstract void Symbol();

        public override void Print()
        {
            Symbol();
        }
    }

    /// <summary>
    /// A class representing the operator +
    /// </summary>
    private class Plus : Operator
    {
        public override float Count()
        {
            if (LeftSon == null || RightSon == null)
            {
                throw new InvalidOperationException();
            }

            return LeftSon.Count() + RightSon.Count();
        }

        public override void Symbol()
        {
            Console.Write("(");
            Console.Write("+");
            LeftSon?.Print();
            RightSon?.Print();
            Console.Write(")");
        }
    }

    /// <summary>
    /// A class representing the operator -
    /// </summary>
    private class Minus : Operator
    {
        public override float Count()
        {
            // But if we consider the input file to be correct, then such a situation should not arise
            if (LeftSon == null || RightSon == null)
            {
                throw new InvalidOperationException();
            }

            return LeftSon.Count() - RightSon.Count();
        }

        public override void Symbol()
        {
            Console.Write("(");
            Console.Write("-");
            LeftSon?.Print();
            RightSon?.Print();
            Console.Write(")");
        }
    }

    /// <summary>
    /// A class representing the operator /
    /// </summary>
    private class Divide : Operator
    {
        public override float Count()
        {
            if (LeftSon == null || RightSon == null)
            {
                throw new InvalidOperationException();
            }

            float rightSonValue = RightSon.Count();
            if (Math.Abs(rightSonValue - 0) < 0.0000000000000000000000000001)
            {
                throw new DivideByZeroException();
            }

            return LeftSon.Count() / rightSonValue;
        }

        public override void Symbol()
        {
            Console.Write("(");
            Console.Write("/");
            LeftSon?.Print();
            RightSon?.Print();
            Console.Write(")");
        }
    }

    /// <summary>
    /// A class representing the operator *
    /// </summary>
    private class Multiplication : Operator
    {
        public override float Count()
        {
            if (LeftSon == null || RightSon == null)
            {
                throw new InvalidOperationException();
            }
            return LeftSon.Count() * RightSon.Count();
        }

        public override void Symbol()
        {
            Console.Write("(");
            Console.Write("");
            LeftSon?.Print();
            RightSon?.Print();
            Console.Write(")");
        }
    }

    private Node? treeRoot;

    /// <summary>
    /// Function for building a tree
    /// </summary>
    /// <param name="expression">The expression that needs to be calculated</param>
    public void BuildTree(string expression)
    {
        int index = 0;
        Node? node = null;
        treeRoot = PrivateBuildTree(expression, ref index, node);
    }

    /// <summary>
    /// Auxiliary function for building a tree
    /// </summary>
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
        if (index < expression.Length - 1 && !IsOperand(expression[index + 1]) && IsOperator(expression[index]))
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

        // This unused variable x is needed in order to call the function,
        // And it is the operand that is initialized,
        // Because the last character of the number cannot be an operator (the file is considered correct
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

    /// <summary>
    /// A function for initializing nodes depending on which operator or operator is a string
    /// </summary>
    private void InitializeNode(string expression, ref int index, ref Node? node)
    {
        switch (expression[index])
        {
            case '+':
                {
                    node = new Plus();
                    index++;
                    ((Plus)node).LeftSon = PrivateBuildTree(expression, ref index, ((Plus)node).LeftSon);
                    ((Plus)node).RightSon = PrivateBuildTree(expression, ref index, ((Plus)node).RightSon);
                    return;
                }
            case '-':
                {
                    node = new Minus();
                    index++;
                    ((Minus)node).LeftSon = PrivateBuildTree(expression, ref index, ((Minus)node).LeftSon);
                    ((Minus)node).RightSon = PrivateBuildTree(expression, ref index, ((Minus)node).RightSon);
                    return;
                }
            case '*':
                {
                    node = new Multiplication();
                    index++;
                    ((Multiplication)node).LeftSon = PrivateBuildTree(expression, ref index, ((Multiplication)node).LeftSon);
                    ((Multiplication)node).RightSon = PrivateBuildTree(expression, ref index, ((Multiplication)node).RightSon);
                    return;
                }
            case '/':
                {
                    node = new Divide();
                    index++;
                    ((Divide)node).LeftSon = PrivateBuildTree(expression, ref index, ((Divide)node).LeftSon);
                    ((Divide)node).RightSon = PrivateBuildTree(expression, ref index, ((Divide)node).RightSon);
                    return;
                }
            default:
                {
                    node = new Operand(expression);
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
            throw new InvalidOperationException();
        }

        return treeRoot.Count();
    }

    private static bool IsOperator(char element) => element == '+' || element == '-' || element == '*' || element == '/';

    private static bool IsOperand(char element) => element <= '9' && element >= '0';
}