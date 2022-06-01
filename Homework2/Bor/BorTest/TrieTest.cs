namespace TrieTest;

using NUnit.Framework;
using Trie;

public class TrieTest
{
    private Trie trie = new();

    [SetUp]
    public void Setup()
    { 
        trie = new();
    }

    [Test]
    public void ShouldExpectedFalseWhenRemoveFromEmptyBor()
    {
        Assert.IsFalse(trie.Remove("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenAddExistingString()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsFalse(trie.Add("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForNonExistingString()
    {
        Assert.IsFalse(trie.Contains("hello"));
    }

    [Test]
    public void ShouldExpectedTrueWhenContainsForExistingString() 
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Contains("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenRemoveForRemovedString()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Remove("hello"));
        Assert.IsFalse(trie.Remove("hello"));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForRemovedString() 
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Remove("hello"));
        Assert.IsFalse(trie.Contains("hello"));
    }

    [Test]
    public void ShouldExpected5WhenSizeForBorContains5Node()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.AreEqual(5, trie.Size);
    }

    [Test]
    public void ShouldBorSizeNotChangeWhenAddExistingSubstring()
    {
        Assert.IsTrue(trie.Add("hello"));
        int size = trie.Size;
        Assert.IsTrue(trie.Add("hell"));
        Assert.AreEqual(size, trie.Size);
    }

    [Test]
    public void ShouldBorSizeEqual8WhenAddStringLength3WithNonExistingFirstSymbolForBorContains5Node()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Add("bye"));
        Assert.AreEqual(8, trie.Size);
    }

    [Test]
    public void ShouldExpected2WhenHowManyStartWithPrefixForBorContains2StringWhichStartWithSamePrefix()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Add("hel"));
        Assert.AreEqual(2, trie.HowManyStartWithPrefix("hel"));
    }

    [Test]
    public void ShouldExpected0WhenHowManyStartWithPrefixForNonExistingPrefix()
    {
        Assert.IsTrue(trie.Add("hello"));
        Assert.IsTrue(trie.Add("bye"));
        Assert.AreEqual(0, trie.HowManyStartWithPrefix("leee"));
    }
}