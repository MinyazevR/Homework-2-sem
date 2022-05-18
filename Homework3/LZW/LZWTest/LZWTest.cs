namespace Test;

using NUnit.Framework;
using System.IO;

public class LZWTests
{
        [Test]
        public void ShouldExpectedStringAreEqualWhenLZWForFile()
        {
            string filename = "..//..//..//Test.txt";
            LZW.LZW.CompressFile(filename);
            string newFilename = "..//..//..//Test.zipped";
            LZW.LZW.DecompressFile(newFilename);
            var firstString = File.ReadAllBytes(filename);
            var secondString = File.ReadAllBytes("..//..//..//Test");
            Assert.AreEqual(firstString, secondString);
        }
}