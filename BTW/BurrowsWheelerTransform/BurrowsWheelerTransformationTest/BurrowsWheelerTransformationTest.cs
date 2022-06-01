namespace BurrowsWheelerTransformationTest;

using NUnit.Framework;
using BurrowsWheelerTransform;
using System.IO;

public class Tests
{

    [Test]
    public void ShouldExpectedEmptyStringWnenBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual("", newString);
        Assert.AreEqual("", StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }

    [Test]
    public void ShouldExpectedOriginalOneCharacterStringWhenBurrowsWheelerTransformationForOneCharacterString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("a");
        Assert.AreEqual("a", newString);
        Assert.AreEqual("a", StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }


    [Test]
    public void ShouldExpectedOriginalRandomStringWhenBurrowsWheelerTransformationForRandomString()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }

    [Test]
    public void ShouldExpectedOriginalStringForEqualSymbolWhenBurrowsWheelerTransformationForStringForEqualSymbol()
    {
        string stringToConvert = File.ReadAllText("..//..//..//test1.txt");
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation(stringToConvert);
        Assert.AreEqual(stringToConvert, StringTransformation.InverseBurrowsWheelerTransformation(newString, index));
    }
}