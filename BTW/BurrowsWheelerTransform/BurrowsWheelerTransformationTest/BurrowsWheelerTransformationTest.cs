using NUnit.Framework;
using BurrowsWheelerTransform;

using System.IO;
namespace BurrowsWheelerTransformationTest;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DirectBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(newString, "");
    }

    [Test]
    public void DirectBurrowsWheelerTransformationForFileString()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }

    [Test]
    public void DirectBurrowsWheelerTransformationForFileStringForEqualSymbol()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test1.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }
}