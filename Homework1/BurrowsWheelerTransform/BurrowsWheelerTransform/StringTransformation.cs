using System;
using System.Collections.Generic;

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
        for (int i = 0; i < stringToConvert.Length; i++)
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
        Dictionary<int, int> storeTheNumberOfCharactersEqualGivenAndStandingHigher = new Dictionary<int, int>();
        Dictionary<char, int> storeTheNumberOfCharactersSmallerGiven = new Dictionary<char, int>();
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            int counter = 0;
            if (!storeTheNumberOfCharactersSmallerGiven.ContainsKey(stringToConvert[i]))
            {
                storeTheNumberOfCharactersSmallerGiven.Add(stringToConvert[i], 0);
            }
            else
            {
                storeTheNumberOfCharactersSmallerGiven.Remove(stringToConvert[i], out counter);
                counter++;
                storeTheNumberOfCharactersSmallerGiven.Add(stringToConvert[i], counter);
            }
            storeTheNumberOfCharactersEqualGivenAndStandingHigher.Add(i, counter);
        }
        var sortStringToConvert = stringToConvert.ToCharArray();
        Array.Sort(sortStringToConvert);
        storeTheNumberOfCharactersSmallerGiven.Clear();
        storeTheNumberOfCharactersSmallerGiven.Add(sortStringToConvert[0], 0);
        for (int i = 0; i < sortStringToConvert.Length - 1; i++)
        {
            if (sortStringToConvert[i] != sortStringToConvert[i + 1])
            {
                storeTheNumberOfCharactersSmallerGiven.Add(sortStringToConvert[i + 1], i + 1);
            }
        }
        char[] answer = new char[stringToConvert.Length];
        answer[answer.Length - 1] = stringToConvert[index];
        for (int i = answer.Length - 1; i > 0; i--)
        {
            int number = 0;
            storeTheNumberOfCharactersEqualGivenAndStandingHigher.TryGetValue(index, out number);
            int secondNumber;
            storeTheNumberOfCharactersSmallerGiven.TryGetValue(stringToConvert[index], out secondNumber);
            index = number + secondNumber;
            answer[i - 1] = stringToConvert[index];
        }
        return new String(answer);
    }
    public class solutoin
    {
        static void Main(string[] args)
        {
        }
    }
}