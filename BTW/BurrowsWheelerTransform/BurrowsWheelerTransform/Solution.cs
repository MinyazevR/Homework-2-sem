namespace BurrowsWheelerTransform;

using System.IO;

public class Solution
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("invalid number of input arguments");
            return; 
        }
        string pathToFile = args[0];
        string text = File.ReadAllText(pathToFile);
        var (str, index) = StringTransformation.DirectBurrowsWheelerTransformation(text);
        string answer = StringTransformation.InverseBurrowsWheelerTransformation(str, index);
        string fileName = Path.GetFileNameWithoutExtension(pathToFile);
        fileName = $"{pathToFile}..\\..\\{fileName}bwt";
        File.WriteAllText(fileName, answer);
    }
}
