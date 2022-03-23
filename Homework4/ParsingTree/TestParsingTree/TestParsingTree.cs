using NUnit.Framework;
using Tree;
using System;

namespace TestParsingTree;

/// <summary>
/// A class for testing a parsing tree
/// </summary>
public class TestsrsingTree
{
    Tree.ParsingTree? tree;

    [SetUp]
    public void Setup()
    {
        tree = new Tree.ParsingTree();
    }

    [Test]
    public void PrintExpressionFromSingleElement()
    {
        tree?.BuildTree("12");
        Assert.AreEqual("12 ", tree?.PrintTree());
        tree?.DeleteTree();
    }

    [Test]
    public void PrintExpressionFromZeroElement()
    {
        tree?.BuildTree("");
        Assert.AreEqual("", tree?.PrintTree());
        tree?.DeleteTree();
    }

    [Test]
    public void PrintExpressionFromRandomElement()
    {
        tree?.BuildTree("(*(-(*(2 7))12)3)");
        Assert.AreEqual("(*(-(*2 7 )12 )3 )", tree?.PrintTree());
        tree?.DeleteTree();
    }

    [Test]
    public void DivideByZeroExpression()
    {
        tree?.BuildTree("/ 2 0");
        Assert.Throws<DivideByZeroTreeException>(() => tree?.TreeTraversal());
    }
}
