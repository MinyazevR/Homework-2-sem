namespace Test;

using NUnit.Framework;
using System.IO;

public class LZWTests
{
    [Test]
    public void ShouldExpectedDecompressedFileAreEqualInitialFileWhenCompressAndDecompressForTxtFile()
    {
        string filename = "..//..//..//Test.txt";
        LZW.LZW.CompressFile(filename);
        string newFilename = "..//..//..//Test.txt.zipped";
        LZW.LZW.DecompressFile(newFilename);
        var firstString = File.ReadAllBytes(filename);
        var secondString = File.ReadAllBytes("..//..//..//DecompressedTest.txt");
        Assert.AreEqual(firstString, secondString);
    }

    [Test]
    public void ShouldExpectedDecompressedFileAreEqualInitialFileWhenCompressAndDecompressForExeFile()
    {
        string filename = "..//..//..//LZW.exe";
        LZW.LZW.CompressFile(filename);
        string newFilename = "..//..//..//LZW.exe.zipped";
        LZW.LZW.DecompressFile(newFilename);
        var firstString = File.ReadAllBytes(filename);
        var secondString = File.ReadAllBytes("..//..//..//DecompressedLZW.exe");
        Assert.AreEqual(firstString, secondString);
    }

    [Test]
    public void ShouldExpectedDecompressedFileAreEqualInitialFileWhenCompressAndDecompressForEmptyFile()
    {
        string filename = "..//..//..//SecondTest.txt";
        LZW.LZW.CompressFile(filename);
        string newFilename = "..//..//..//SecondTest.txt.zipped";
        LZW.LZW.DecompressFile(newFilename);
        var firstString = File.ReadAllBytes(filename);
        var secondString = File.ReadAllBytes("..//..//..//DecompressedSecondTest.txt");
        Assert.AreEqual(firstString, secondString);
    }
}