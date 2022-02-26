using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurrowsWheelerTransform;

namespace TestBurrowsWheelerTransform;

[TestClass]
public class InverseBurrowsWheelerTransformationTest
{
    [TestMethod]
    public void FirstRandomInverseBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("ABACABA");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "ABACABA");
    }

    [TestMethod]
    public void SecondRandomInverseBurrowsWheelerTransformation()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("АБРАКАДАБРА");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "АБРАКАДАБРА");
    }

    [TestMethod]
    public void InverseBurrowsWheelerTransformationForEmptyString()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "");
    }

    [TestMethod]
    public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
    {
        var (newString, index) = StringTransformation.DirectBurrowsWheelerTransformation("aaaaaaaa");
        Assert.AreEqual(StringTransformation.InverseBurrowsWheelerTransformation(newString, index), "aaaaaaaa");
    }
}