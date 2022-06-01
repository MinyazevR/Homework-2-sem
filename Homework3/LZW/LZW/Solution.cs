if (args.Length != 2)
{
    Console.WriteLine("The first argument should be the path to the file, " +
              "the second argument is the key -c if you need to compress the file, the key -u if you decompress");
    return;
}

string pathToFile = args[0];

if (args[1] == "-c")
{
    var file = new FileInfo(pathToFile);
    long uncompressedFileSize = file.Length;
    string fileName = $"{pathToFile}.zipped";
    LZW.LZW.CompressFile(pathToFile);
    file = new FileInfo(fileName);
    long compressedFileSize = file.Length;
    Console.WriteLine((float)(uncompressedFileSize) / (float)compressedFileSize);
    return;
}
else if (args[1] == "-u")
{
    LZW.LZW.DecompressFile(pathToFile);
}
else
{
    Console.WriteLine("Invalid key entered");
}
