using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurrowsWheelerTransform;
namespace TestBurrowsWheelerTransform
{
    [TestClass]
    public class DirectBurrowsWheelerTransformationTest
    {
        [TestMethod]
        public void FirstRandomDirectBurrowsWheelerTransformation()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("ABACABA", ref number);
            Assert.AreEqual(newString, "BCABAAA");
        }
        [TestMethod]
        public void SecondRandomDirectBurrowsWheelerTransformation()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("¿¡–¿ ¿ƒ¿¡–¿", ref number);
            Assert.AreEqual(newString, "–ƒ¿ –¿¿¿¿¡¡");
        }
        [TestMethod]
        public void DirectBurrowsWheelerTransformationForEmptyString()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("", ref number);
            Assert.AreEqual(newString, "");
        }
        [TestMethod]
        public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("aaaaaaaa", ref number);
            Assert.AreEqual(newString, "aaaaaaaa");
        }
    }

    [TestClass]
    public class InverseBurrowsWheelerTransformationTest
    {
        [TestMethod]
        public void FirstRandomInverseBurrowsWheelerTransformation()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("ABACABA", ref number);
            Assert.AreEqual(program.InverseBurrowsWheelerTransformation(newString, number), "ABACABA");
        }
        [TestMethod]
        public void SecondRandomInverseBurrowsWheelerTransformation()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("¿¡–¿ ¿ƒ¿¡–¿", ref number);
            Assert.AreEqual(program.InverseBurrowsWheelerTransformation(newString, number), "¿¡–¿ ¿ƒ¿¡–¿");
        }
        [TestMethod]
        public void InverseBurrowsWheelerTransformationForEmptyString()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("", ref number);
            Assert.AreEqual(program.InverseBurrowsWheelerTransformation(newString, number), "");
        }
        [TestMethod]
        public void DirectBurrowsWheelerTransformationForStringOfEqualSymbol()
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            string newString = program.DirectBurrowsWheelerTransformation("aaaaaaaa", ref number);
            Assert.AreEqual(program.InverseBurrowsWheelerTransformation(newString, number), "aaaaaaaa");
        }
    }
}
