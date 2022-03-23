using System;

namespace Tree;

/// <summary>
/// Class representing the parse tree
/// </summary>
public class ParsingTree : IParsingTree
{
    /// <summary>
    /// Class for storing tree nodes
    /// </summary>
    public class Node
    {
        private Node? leftSon;
        private Node? rightSon;
        private string? stringValue;
        public Node? LeftSon { get => leftSon; set { leftSon = value; } }
        public Node? RightSon { get => rightSon; set { rightSon = value; } }
        public string? Value { get => stringValue; set { stringValue = value; } }

    }

    private Node? treeRoot;

    /// <summary>
    /// Function for deleting a tree
    /// </summary>
    public void DeleteTree()
    {
        DeleteTreeRecursive(treeRoot);
    }

    private void DeleteTreeRecursive(Node? root)
    {
        if (root == null)
        {
            return;
        }
        DeleteTreeRecursive(root.LeftSon);
        DeleteTreeRecursive(root.RightSon);
        root = null;
    }

    /// <summary>
    /// Function for traversing the tree
    /// </summary>
    public float TreeTraversal()
    {
        return RecursiveTreeTraversal(treeRoot);
    }

    private float RecursiveTreeTraversal(Node? root)
    {
        if (root == null || root.Value == null)
        {
            return 0;
        }
        if (root.LeftSon != null)
        {
            RecursiveTreeTraversal(root.LeftSon);
        }
        if (root.RightSon != null)
        {
            RecursiveTreeTraversal(root.RightSon);
        }
        if (root.RightSon != null && root.LeftSon != null && root.LeftSon.Value != null && root.RightSon.Value != null)
        {
            if (root.Value == "+")
            {
                root.Value = (float.Parse(root.LeftSon.Value) + float.Parse(root.RightSon.Value)).ToString();
            }
            if (root.Value == "-")
            {
                root.Value = (float.Parse(root.LeftSon.Value) - float.Parse(root.RightSon.Value)).ToString();
            }
            if (root.Value == "*")
            {
                root.Value = (float.Parse(root.LeftSon.Value) * float.Parse(root.RightSon.Value)).ToString();
            }
            if (root.Value == "/")
            {
                try
                {
                    if (float.Parse(root.RightSon.Value).CompareTo(0) == 0)
                    {
                        throw new DivideByZeroTreeException("division by 0");
                    }
                }
                catch (DivideByZeroTreeException exception)
                {
                    Console.WriteLine($"Ошибка: {exception.Message}");
                    throw;
                }
                root.Value = (float.Parse(root.LeftSon.Value) / float.Parse(root.RightSon.Value)).ToString();
            }
        }
        return float.Parse(root.Value);
    }

    /// <summary>
    /// Function for printing a tree
    /// </summary>
    public string PrintTree()
    {
        string element = "";
        PrintTreeRecursive(ref element, treeRoot);
        return element;
    }

    private void PrintTreeRecursive(ref string element, Node? root)
    {
        if (root == null)
        {
            return;
        }
        if (root.Value != null && StringIsOperator(root.Value))
        {
            element += "(";
            element += root.Value;
            PrintTreeRecursive(ref element, root.LeftSon);
            PrintTreeRecursive(ref element, root.RightSon);
            element += ")";

        }
        else
        {
            element += root.Value;
            element += " ";
        }
    }

    /// <summary>
    /// Function for building a tree
    /// </summary>
    /// <param name="expression">The expression on the basis of which the tree is built</param>
    public void BuildTree(string expression)
    {
        int index = 0;
        Node? root = null;
        treeRoot = PrivateBuildTree(expression, ref index, root);
    }

    private Node? PrivateBuildTree(string expression, ref int index, Node? node)
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
            node = InitializeNode("" + expression[index]);
            index++;
            node.LeftSon = PrivateBuildTree(expression, ref index, node.LeftSon);
            node.RightSon = PrivateBuildTree(expression, ref index, node.RightSon);
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
        Node newNode = expression[index] == '-' ? InitializeNode("-" + nodeValue) : InitializeNode(nodeValue);
        index = newIndex;
        return newNode;
    }

    private Node InitializeNode(string element)
    {
        Node newNode = new Node();
        newNode.Value = element;
        return newNode;
    }

    private bool CharIsOperator(char element) => element == '+' || element == '-' || element == '*' || element == '/';
    private bool StringIsOperator(string element) => element == "+" || element == "-" || element == "*" || element == "/";
    private bool IsOperand(char element) => element <= '9' && element >= '0';
}
