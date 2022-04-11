namespace Tree;

using System;

/// <summary>
/// Class representing the parse tree
/// </summary>
public class ParsingTree
{
    /// <summary>
    /// Class for storing tree nodes
    /// </summary>
    private interface INode
    {
        public float Count();
        public void Print();

        public class Operand : INode
        {
            public string Value;
            public Operand(string element)
            {
                Value = element;
            }
            public float Count()
            {
                return float.Parse(Value);
            }
            public void Print()
            {
                Console.Write(Value);
                Console.Write(" ");
            }
        }

        public abstract class Operator : INode
        {
            public INode? LeftSon;
            public INode? RightSon;
            public abstract float Count();
            public abstract void Print();

            public void OperatorPrintTemplate(string symbol)
            {
                Console.Write("(");
                Console.Write(symbol);
                LeftSon?.Print();
                RightSon?.Print();
                Console.Write(")");
            }

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

            public class Multiply : Operator
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

    INode? treeRoot;

    public void BuildTree(string expression)
    {
        int index = 0;
        INode? root = null;
        treeRoot = PrivateBuildTree(expression, ref index, root);
    }

    private INode? PrivateBuildTree(string expression, ref int index, INode? node)
    {
        if (index >= expression.Length)
        {
            return node;
        }
        while (expression[index] == '(' || expression[index] == ')' || expression[index] == ' ' && index < expression.Length)
        {
            index++;
        }
        if ((CharIsOperator(expression[index]) && index < expression.Length) || (index + 1 < expression.Length
        && !IsOperand(expression[index + 1]) && CharIsOperator(expression[index])))
        {
            InitializeNode(expression, ref index, ref node);
            return node;
        }
        int newIndex = expression[index] == '-' ? index + 1 : index;
        string nodeValue = "";
        while (newIndex < expression.Length &&
        IsOperand(expression[newIndex]))
        {
            nodeValue += expression[newIndex];
            newIndex++;
        }
        INode? newNode = null;
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

    private void InitializeNode(string expression, ref int index, ref INode? node)
    {
        switch (expression[index])
        {
            case '+':
            {
                node = new INode.Operator.Plus();
                index++;
                ((INode.Operator.Plus)node).LeftSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Plus)node).LeftSon);
                ((INode.Operator.Plus)node).RightSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Plus)node).RightSon);
                return;
            }
            case '-':
            {
                node = new INode.Operator.Minus();
                index++;
                ((INode.Operator.Minus)node).LeftSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Minus)node).LeftSon);
                ((INode.Operator.Minus)node).RightSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Minus)node).RightSon);
                return;
            }
            case '*':
            {
                node = new INode.Operator.Multiply();
                index++;
                ((INode.Operator.Multiply)node).LeftSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Multiply)node).LeftSon);
                ((INode.Operator.Multiply)node).RightSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Multiply)node).RightSon);
                return;
            }
            case '/':
            {
                node = new INode.Operator.Divide();
                index++;
                ((INode.Operator.Divide)node).LeftSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Divide)node).LeftSon);
                ((INode.Operator.Divide)node).RightSon = PrivateBuildTree(expression, ref index, ((INode.Operator.Divide)node).RightSon);
                return;
            }
            default:
            {
                node = new INode.Operand(expression);
                index++;
                return;
            }
        }
    }

    public void Print() => treeRoot?.Print();
    public float Count()
    {
        if (treeRoot == null)
            throw new NullReferenceException();
        return treeRoot.Count();
        
    }
    private bool CharIsOperator(char element) => element == '+' || element == '-' || element == '*' || element == '/';
    private bool IsOperand(char element) => element <= '9' && element >= '0';
}

public class Solution
{
    public static void Main(string[] args)
    {
        ParsingTree tree = new ParsingTree();
        tree.BuildTree("(* (+ 1 1) 2)");
        tree.Print();
        Console.Write(tree.Count());
    }
}
