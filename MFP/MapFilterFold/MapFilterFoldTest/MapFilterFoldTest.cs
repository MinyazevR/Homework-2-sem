using NUnit.Framework;
using MFP;
using System.Collections.Generic;

namespace MFPTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MultiplyEachListItemBy2()
    {
        Assert.AreEqual(MFP.MFP.Map<int>(new List<int>() { 1, 2, 3 }, x => x * 2), new List<int> { 2, 4, 6 });
    }

    [Test]
    public void AddSdfToEachLine()
    {
        Assert.AreEqual(MFP.MFP.Map<string>(new List<string>() { "a", "b", "sg" }, x => x + "sdf"), new List<string> { "asdf", "bsdf", "sgsdf" });
    }

    [Test]
    public void FindEvenListItems()
    {
        Assert.AreEqual(MFP.MFP.Filter<int>(new List<int>() { 23, 12, 19, 8, 24, 7 }, x => x % 2 == 0), new List<int> { 12, 8, 24 });
    }

    [Test]
    public void FindTheStringsThatStartWithP()
    {
        Assert.AreEqual(MFP.MFP.Filter<string>(new List<string>() { "pap", "b", "sg", "pty" }, x => x[0] == 'p'), new List<string> { "pap", "pty" });
    }

    [Test]
    public void ExampleFromCondition()
    {
        Assert.AreEqual(MFP.MFP.Fold<int>(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem), 6);
    }

    [Test]
    public void ConcatenateListItems()
    {
        Assert.AreEqual(MFP.MFP.Fold<string>(new List<string>() { "lol", "kek", "ab" }, "", (acc, elem) => acc + elem), "lolkekab");
    }
}