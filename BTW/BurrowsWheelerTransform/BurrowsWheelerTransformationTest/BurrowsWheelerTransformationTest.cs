using NUnit.Framework;
using BurrowsWheelerTransform;

using System.IO;
namespace BurrowsWheelerTransformationTest;

public class Tests
{

    [Test]
    public void BurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(newString, "");
    }

    [Test]
    public void BurrowsWheelerTransformationForFileString()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }

    [Test]
    public void BurrowsWheelerTransformationForFileStringForEqualSymbol()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test1.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }
}