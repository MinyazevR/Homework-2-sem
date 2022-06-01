namespace LZW;

using System;
using System.IO;
using Trie;

/// <summary>
/// A class representing the LZW algorithm
/// </summary>
public class LZW
{
    /// <summary>
    /// A function for determining the number of bytes needed to store a number
    /// </summary>
    private static int NumberOfBytes(int number)
    {
        if (number < 256)
        {
            return 1;
        }
        if (number < 65536)
        {
            return 2;
        }
        if (number < 16777216)
        {
            return 3;
        }
        return 4;
    }

    /// <summary>
    /// Function for file compression
    /// </summary>
    /// <param name="pathToFileToCompress">The path to the file to compress</param>
    public static void CompressFile(string pathToFileToCompress)
    {
        // Name of the compressed file
        string fileName = $"{pathToFileToCompress}.zipped";

        // Create file
        using FileStream fs = new(fileName, FileMode.Create);

        // Reading all bytes from a file
        var stringToConvert = File.ReadAllBytes(pathToFileToCompress);

        // Creating bor
        Trie bor = new();

        if (stringToConvert.Length == 0)
        {
            return;
        }

        for (int i = 0; i < stringToConvert.Length; i++)
        {
            // If the byte is contained in the bor
            if (bor.Contains(stringToConvert[i]))
            {
                // Moving on to the next byte
                bor.MoveIntoDesiredNode(stringToConvert[i]);
            }

            // Otherwise, we add it to the bor
            else
            {
                // Taking the idex from the parent vertex and encode it
                var bytes = BitConverter.GetBytes(bor.GetCode());

                /* Cut off the extra bytes
                    The required number of bytes is selected according to the size of the bor
                    Since among the numbers that need to be encoded there may be a bor size (index of the maximum vertex),
                    the number of bytes to store depends on the size of the bor.
                    Even a number requires fewer bytes,
                    it is written in a large number of bytes so that it can be decoded later. */
                Array.Resize(ref bytes, NumberOfBytes(bor.Size - 1));
                bor.Add(stringToConvert[i]);
                fs.Write(bytes);

                // Going back to the last vertex
                i--;
            }
        }

        // The last bytes that are already in the dictionary and that are not written in the loop
        var newbytes = BitConverter.GetBytes(bor.GetCode());
        Array.Resize(ref newbytes, NumberOfBytes(bor.Size));
        fs.Write(newbytes);
    }

    /// <summary>
    /// Function for file decompression
    /// </summary>
    /// <param name="pathToFile">The path to the file to decompress</param>
    public static void DecompressFile(string pathToFile)
    {
        var currentDirectoryName = Path.GetDirectoryName(pathToFile);
        var fileName = Path.GetFileName(pathToFile);

        // 7 = .zipped.length
        fileName = $"{currentDirectoryName}//Decompressed{fileName[0..(fileName.Length - 7)]}";

        // Create file
        using FileStream fs = new(fileName, FileMode.Create);

        // Reading all bytes from a file
        byte[] stringToConvert = File.ReadAllBytes(pathToFile);

        // Dictionary for decoding
        var dictionary = new Dictionary<int, byte[]>();

        for (int i = 0; i < 256; i++)
        {
            var byteArray = BitConverter.GetBytes(i);
            dictionary.Add(i, byteArray[0..1]);
        }

        int rightBorder = 0;
        int leftBorder = 0;
        bool flag = false;

        while (leftBorder < stringToConvert.Length)
        {
            // The right border of the current subarray
            rightBorder = leftBorder + NumberOfBytes(dictionary.Count - 1) - 1;

            // If the right border has gone beyond the edge, then we will make it the last byte
            rightBorder = rightBorder > stringToConvert.Length - 1 ? stringToConvert.Length - 1 : rightBorder;

            if (leftBorder > stringToConvert.Length - 1)
            {
                break;
            }

            // Converting bytes to int
            var bytes = new byte[4];
            Array.Copy(stringToConvert, leftBorder, bytes, 0, NumberOfBytes(dictionary.Count - 1));
            leftBorder = rightBorder + 1;
            int answer = BitConverter.ToInt32(bytes);

            // If it is the first number
            if (!flag)
            {
                flag = true;
            }

            // Otherwise, we concatenate the last element with the first byte of the current one
            else
            {
                var newArray = new byte[dictionary[dictionary.Count - 1].Length + 1];
                Array.Copy(dictionary[dictionary.Count - 1], newArray, dictionary[dictionary.Count - 1].Length);
                newArray[newArray.Length - 1] = dictionary[answer][0];
                // Changing the value in the dictionary to the value we need
                dictionary[dictionary.Count - 1] = newArray;
            }

            // Adding a new element to the dictionary
            dictionary.Add(dictionary.Count, dictionary[answer]);
            fs.Write(dictionary[answer]);
        }
    }
}