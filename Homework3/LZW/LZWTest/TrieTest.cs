namespace Test;

using NUnit.Framework;
using Trie;
using System;

public class TrieTest
{
    Trie bor = new();

    [SetUp]
    public void Setup()
    {
        bor = new();
    }

    [Test]
    public void ShouldExpectedTrueWhenContainsForBorWhereinCurrentNodeContainsThisNode()
    {
        bor.MoveIntoDesiredNode((byte)123);
        bor.Add((byte)143);
        bor.MoveIntoDesiredNode((byte)123);
        Assert.IsTrue(bor.Contains((byte)143));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForBorWhereinCurrentNodeContainsThisNode()
    {
        bor.MoveIntoDesiredNode((byte)123);
        Assert.IsFalse(bor.Contains((byte)143));
    }

    [Test]
    public void ShouldBorSizeIncreaseByOneWhenAdd()
    {
        bor.MoveIntoDesiredNode((byte)123);
        var size = bor.Size;
        bor.Add((byte)12);
        Assert.AreEqual(size + 1, bor.Size);
    }

    [Test]
    public void ShouldWhenAddExistingNode()
    {
        Assert.Throws<ArgumentException>(() => bor.Add((byte)12));
    }

    [Test]
    public void ShouldExpectedCurrentRootEqualRootWhenMoveToRoot()
    {
        bor.MoveIntoDesiredNode((byte)123);
        bor.MovedToRoot();
        Assert.AreEqual(-1, bor.GetCode());
    }

    [Test]
    public void ShouldExpectedCurrentRootWhenMoveIntoDesiredNode()
    {
        bor.MoveIntoDesiredNode((byte)123);
        Assert.AreEqual(123, bor.GetCode());
    }
}