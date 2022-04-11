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
}