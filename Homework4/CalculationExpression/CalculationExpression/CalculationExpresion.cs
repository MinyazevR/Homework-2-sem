using System;
using Tree;

namespace CalculationExpression;

public class CalculatExpression
{
    IParsingTree tree = new Tree.ParsingTree();
    public float CountTheExpression(string expression)
    {
        tree.BuildTree(expression);
        float answer = tree.TreeTraversal();
        tree.DeleteTree();
        tree.BuildTree(expression);
        return answer;
    }

    public void PrintExpression(string expression)
    {
        tree.PrintTree();
    }

    public void DeleteExpression(string expression)
    {
        tree.DeleteTree();
    }
}