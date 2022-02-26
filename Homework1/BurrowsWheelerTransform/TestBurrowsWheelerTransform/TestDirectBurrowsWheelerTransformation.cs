using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurrowsWheelerTransform;

namespace TestBurrowsWheelerTransform;

[TestClass]
public class DirectBurrowsWheelerTransformationTest
{ 
    [TestMethod]
    public void FirstRandomDirectBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("ABACABA");
        Assert.AreEqual(newString, "BCABAAA");
    }

    [TestMethod]
    public void SecondRandomDirectBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("¿¡–¿ ¿ƒ¿¡–¿");
        Assert.AreEqual(newString, "–ƒ¿ –¿¿¿¿¡¡");
    }

    [TestMethod]
    public void DirectBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(newString, "");
    }

    [TestMethod]
    public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("aaaaaaaa");
        Assert.AreEqual(newString, "aaaaaaaa");
    }
}
