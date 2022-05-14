namespace LZW;

public class Solution
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            throw new FileNotFoundException();
        }
        string pathToFile = args[0];
        if (args[1] == "-c")
        {
            var file = new FileInfo(pathToFile);
            long uncompressedFileSize = file.Length;
            string fileName = Path.GetFileNameWithoutExtension(pathToFile);
            fileName = $"{pathToFile}..\\..\\{fileName}.zipped";
            LZW.CompressFile(pathToFile);
            file = new FileInfo(fileName);
            long compressedFileSize = file.Length;
            Console.WriteLine((float)(uncompressedFileSize) / (float)compressedFileSize);
            return;
        }
        if (args[1] == "-u")
        {
            LZW.DecompressFile(pathToFile);
        }
    }
}
