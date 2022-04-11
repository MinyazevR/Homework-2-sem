namespace TestParsingTree;

using NUnit.Framework;
using ParsingTree;
using System.IO;
using System;


/// <summary>
/// A class for testing a parsing tree
/// </summary>
public class TestsrsingTree
{
    ParsingTree tree = new();

    [SetUp]
    public void Setup()
    {
        tree = new ();
    }

    [Test]
    public void ShouldExpected4WhenExpressionEqual4()
    {
        string stringToConvert = File.ReadAllText("..//..//..//FirstTest.txt");
        tree.BuildTree(stringToConvert);
        Assert.AreEqual(4 , tree.Count());
    }

    [Test]
    public void ShouldExpectedOneNumberWhenExpressionContainsOnlyOneNumber()
    {
        string stringToConvert = "12";
        tree.BuildTree(stringToConvert);
        Assert.AreEqual(12, tree.Count());
    }

    [Test]
    public void ShouldExpectedThrowsNullReferenceExceptionWhenExpressionIsEmptyString()
    {
        string stringToConvert = "";
        tree.BuildTree(stringToConvert);
        Assert.Throws<NullReferenceException>(() => tree.Count());
    }
}