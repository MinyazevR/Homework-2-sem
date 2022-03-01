using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurrowsWheelerTransform;

namespace TestBurrowsWheelerTransform;

// A class for testing the direct Burrows - Wheeler transformation
[TestClass]
public class DirectBurrowsWheelerTransformationTest
{
    // Function for reverse conversion test on a specific string
    [TestMethod]
    public void FirstRandomDirectBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("ABACABA");
        Assert.AreEqual(newString, "BCABAAA");
    }

    // Function for reverse conversion test on a specific string
    [TestMethod]
    public void SecondRandomDirectBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("¿¡–¿ ¿ƒ¿¡–¿");
        Assert.AreEqual(newString, "–ƒ¿ –¿¿¿¿¡¡");
    }

    // Function for reverse conversion test on an empty string
    [TestMethod]
    public void DirectBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(newString, "");
    }

    // Function for the reverse conversion test on strings of identical characters
    [TestMethod]
    public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("aaaaaaaa");
        Assert.AreEqual(newString, "aaaaaaaa");
    }
}
