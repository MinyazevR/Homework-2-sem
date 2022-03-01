using System;

namespace BurrowsWheelerTransform;

// A class for implementing the Burrows - Wheeler transformation
public class StringTransformation
{
    // Function for direct Burrows - Wheeler transormation
    // The input argument is a string
    // The function returns the transformed string and the index of the string for the reverse conversion
    public static (string, int) DirectBurrowsWheelerTransformation(string stringToConvert)
    {
        var arrayOfString = new string[stringToConvert.Length];
        string convertedString = "";
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            arrayOfString[i] = stringToConvert;
            char symbol = stringToConvert[stringToConvert.Length - 1];
            stringToConvert = stringToConvert.Remove(stringToConvert.Length - 1, 1);
            stringToConvert = symbol + stringToConvert;
        }
        Array.Sort(arrayOfString);
        for(int i  = 0; i < stringToConvert.Length; i++)
        {
            convertedString += arrayOfString[i][stringToConvert.Length - 1];
        }
        return (convertedString, Array.IndexOf(arrayOfString, stringToConvert));
    }

    // Function for inverse Burrows - Wheeler transormation
    // Input arguments are the transformed string and the index of the string in the array
    // The function returns the string in its original form
    public static string InverseBurrowsWheelerTransformation(string stringToConvert, int index)
    {
        if (stringToConvert == "")
        {
           return stringToConvert;
        }
        var newArray = stringToConvert.ToCharArray();
        Array.Sort(newArray);
        var newString = new string[stringToConvert.Length];
        for (int i = 0; i < newString.Length; i++)
        {
            newString[i] += newArray[i];
        }
        for (int i = 1; i < stringToConvert.Length; i++)
        {
            Array.Sort(newString);
            for (int j = 0; j < stringToConvert.Length; j++)
            {
                newString[j] = stringToConvert[j] + newString[j];
            }
        }
        Array.Sort(newString);
        return newString[index];
    }
    static void Main(string[] args)
    {
        Console.WriteLine("please enter the line");
        var inputString = Console.ReadLine();
        var (newString, number) = DirectBurrowsWheelerTransformation(inputString);
        Console.WriteLine($"Direct conversion and index line in a table : {newString} , {number}") ;
        Console.WriteLine($"Inverse conversion : {InverseBurrowsWheelerTransformation(newString, number)}");
    }
}