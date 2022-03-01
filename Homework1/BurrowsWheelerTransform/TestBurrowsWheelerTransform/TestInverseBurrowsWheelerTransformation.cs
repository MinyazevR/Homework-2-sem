using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurrowsWheelerTransform;

namespace TestBurrowsWheelerTransform;

// A class for testing the inverse Burrows - Wheeler transformation
[TestClass]
public class InverseBurrowsWheelerTransformationTest
{
    // Function for reverse conversion test on a specific string
    [TestMethod]
    public void FirstRandomInverseBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("ABACABA");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "ABACABA");
    }

    // Function for reverse conversion test on a specific string
    [TestMethod]
    public void SecondRandomInverseBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("АБРАКАДАБРА");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "АБРАКАДАБРА");
    }

    // Function for reverse conversion test on an empty string
    [TestMethod]
    public void InverseBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "");
    }

    // Function for the reverse conversion test on strings of identical characters
    [TestMethod]
    public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("aaaaaaaa");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "aaaaaaaa");
    }
}