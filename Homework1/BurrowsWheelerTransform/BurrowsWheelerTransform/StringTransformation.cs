using System;
using System.IO;
using System.Collections.Generic;

namespace BurrowsWheelerTransform;

/// <summary>
/// A class for implementing the Burrows - Wheeler transformation
/// </summary>
public class StringTransformation
{
    /// <summary>
    /// Function for direct Burrows - Wheeler transormation
    /// </summary>
    /// <param name="stringToConvert">The input argument is a string</param>
    /// <returns>The function returns the transformed string and the index of the string for the reverse conver</returns>
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

    /// <summary>
    /// Function for inverse Burrows - Wheeler transormation
    /// </summary>
    /// <param name="stringToConvert">transformed string</param>
    /// <param name="index">index of the string in the array</param>
    /// <returns>The function returns the string in its original form</returns>
    public static string InverseBurrowsWheelerTransformation(string stringToConvert, int index)
    {
        if (stringToConvert == "")
        {
            return stringToConvert;
        }
        // Словарь для хранения символов стоящих раньше символа и равных ему
        Dictionary<int, int> storeTheNumberOfCharactersEqualGivenAndStandingHigher = new Dictionary<int, int>();

        Dictionary<char, int> storeTheNumberOfCharactersSmallerGiven = new Dictionary<char, int>();

        // Для каждого символа в строке ищем количество равных ему, но стоящих в строке раньше
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            int counter = 0;
            // Если символ встречается впервые, ключ равен 0
            if (!storeTheNumberOfCharactersSmallerGiven.ContainsKey(stringToConvert[i]))
            {
                storeTheNumberOfCharactersSmallerGiven.Add(stringToConvert[i], 0);
            }
            // Иначе значение ключа += 1
            else
            {
                storeTheNumberOfCharactersSmallerGiven.Remove(stringToConvert[i], out counter);
                counter++;
                storeTheNumberOfCharactersSmallerGiven.Add(stringToConvert[i], counter);
            }
            storeTheNumberOfCharactersEqualGivenAndStandingHigher.Add(i, counter);
        }

        // Для каждого символа ищем количество меньших
        // Для этого отсортируем строку и будем искать несовпадающие i и i + 1 символы => для i + 1 символа существует i + 1 меньших чем он
        var sortStringToConvert = stringToConvert.ToCharArray();
        Array.Sort(sortStringToConvert);
        storeTheNumberOfCharactersSmallerGiven.Clear();
        // Для первого символа количество меньших = 1, т.к. он первый в отсортированном массиве
        storeTheNumberOfCharactersSmallerGiven.Add(sortStringToConvert[0], 0);
        for (int i = 0; i < sortStringToConvert.Length - 1; i++)
        {
            if (sortStringToConvert[i] != sortStringToConvert[i + 1])
            {
                storeTheNumberOfCharactersSmallerGiven.Add(sortStringToConvert[i + 1], i + 1);
            }
        }
        // Предпоследний символ строки стоит в трансформированной строке на той же позиции что и строка начинающаяся с последнего символа в таблице сдвигов
        // Строка n 1 2 3 ... n - 1 находится на позиции = k + l, где k - количество символов стоящих nравных n, но стоящих раньше в трансформированной строке,
        // т.к. префикс этих строк меньше и в отсортированной таблице они будут стоять раньше. l - количество символов, меньших n-1
        // Нашли n - 2, найдем n - 3 ...
        char[] answer = new char[stringToConvert.Length];
        answer[answer.Length - 1] = stringToConvert[index];
        for (int i = answer.Length - 1; i > 0; i--)
        {
            int number = storeTheNumberOfCharactersEqualGivenAndStandingHigher[index];
            int secondNumber = storeTheNumberOfCharactersSmallerGiven[stringToConvert[index]];
            index = number + secondNumber;
            answer[i - 1] = stringToConvert[index];
        }
        return new String(answer);
    }
    public class solutoin
    {
        static void Main(string[] args)
        {
            string pathToFile = args[0];
            string text = File.ReadAllText(pathToFile);
            var (str, index) = DirectBurrowsWheelerTransformation(text);
            string answer = StringTransformation.InverseBurrowsWheelerTransformation(str, index);
            string fileName = Path.GetFileNameWithoutExtension(pathToFile);
            fileName = pathToFile + "..\\..\\" + fileName + "bwt";
            File.WriteAllText(fileName, answer);
        }
    }
}