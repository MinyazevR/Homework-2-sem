namespace BorTest;

using NUnit.Framework;
using Bor;

public class BorTest
{
    Bor bor = new();
    [SetUp]
    public void Setup()
    { 
        bor = new();
    }

    [Test]
    public void ShouldExpectedFalseWhenRemoveFromEmptyBor()
    {
        Assert.IsFalse(bor.Remove("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenAddExistingString()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsFalse(bor.Add("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForNonExistingString()
    {
        Assert.IsFalse(bor.Contains("hello"));
    }

    [Test]
    public void ShouldExpectedTrueWhenContainsForExistingString() 
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Contains("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenRemoveForRemovedString()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Remove("hello"));
        Assert.IsFalse(bor.Remove("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForRemovedString() 
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Remove("hello"));
        Assert.IsFalse(bor.Contains("hello"));
    }

    [Test]
    public void ShouldExpected5WhenSizeForBorContains5Node()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.AreEqual(5, bor?.Size());
    }

    [Test]
    public void ShouldBorSizeNotChangeWhenAddExistingSubstring()
    {
        Assert.IsTrue(bor.Add("hello"));
        int size = bor.Size();
        Assert.IsTrue(bor.Add("hell"));
        Assert.AreEqual(size, bor.Size());
    }

    [Test]
    public void ShouldBorSizeEqual8WhenAddStringLength3WithNonExistingFirstSymbolForBorContains5Node()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Add("bye"));
        Assert.AreEqual(8, bor.Size());
    }

    [Test]
    public void ShouldExpected2WhenHowManyStartWithPrefixForBorContains2StringWhichStartWithThisPrefix()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Add("hel"));
        Assert.AreEqual(2, bor.HowManyStartWithPrefix("hel"));
    }

    [Test]
    public void ShouldExpected0WhenHowManyStartWithPrefixForNonExistingPrefix()
    {
        Assert.IsTrue(bor.Add("hello"));
        Assert.IsTrue(bor.Add("bye"));
        Assert.AreEqual(0, bor.HowManyStartWithPrefix("leee"));
    }
}