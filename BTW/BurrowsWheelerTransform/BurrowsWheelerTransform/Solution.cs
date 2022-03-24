using System;
using BurrowsWheelerTransform;
using System.IO;

public class Solution
{
    static void Main(string[] args)
    {
        string pathToFile = args[0];
        string text = File.ReadAllText(pathToFile);
        var (str, index) = StringTransformation.DirectBurrowsWheelerTransformation(text);
        string answer = StringTransformation.InverseBurrowsWheelerTransformation(str, index);
        string fileName = Path.GetFileNameWithoutExtension(pathToFile);
        fileName = pathToFile + "..\\..\\" + fileName + "bwt";
        File.WriteAllText(fileName, answer);
    }
}
