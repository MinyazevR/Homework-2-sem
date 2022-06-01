namespace BurrowsWheelerTransform;

using System;
using System.Collections.Generic;

/// <summary>
/// A class for implementing the Burrows - Wheeler transformation
/// </summary>
public class StringTransformation
{
    /// <summary>
    /// Function for direct Burrows - Wheeler transormation
    /// </summary>
    /// <param name="stringToConvert">The input argument is a string</param>
    /// <returns>The function returns the transformed string and the index of the string for the reverse conversion</returns>
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

        // Словарь для хранения символов, стоящих раньше символа и равных ему
        var theNumberOfCharactersEqualGivenAndStandingHigher = new Dictionary<int, int>();

        var theNumberOfCharactersSmallerGiven = new Dictionary<char, int>();

        // Для каждого символа в строке ищем количество равных ему, но стоящих в строке раньше
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            int counter = 0;
            // Если символ встречается впервые, ключ равен 0
            if (!theNumberOfCharactersSmallerGiven.ContainsKey(stringToConvert[i]))
            {
                theNumberOfCharactersSmallerGiven.Add(stringToConvert[i], 0);
            }

            // Иначе значение ключа += 1
            else
            {
                theNumberOfCharactersSmallerGiven.Remove(stringToConvert[i], out counter);
                counter++;
                theNumberOfCharactersSmallerGiven.Add(stringToConvert[i], counter);
            }

            theNumberOfCharactersEqualGivenAndStandingHigher.Add(i, counter);
        }

        // Для каждого символа ищем количество меньших
        // Для этого отсортируем строку и будем искать несовпадающие i и i + 1 символы => для i + 1 символа существует i + 1 меньших чем он
        var sortStringToConvert = stringToConvert.ToCharArray();
        Array.Sort(sortStringToConvert);
        theNumberOfCharactersSmallerGiven.Clear();
        // Для первого символа количество меньших = 0, т.к. он первый в отсортированном массиве
        theNumberOfCharactersSmallerGiven.Add(sortStringToConvert[0], 0);
        for (int i = 0; i < sortStringToConvert.Length - 1; i++)
        {
            if (sortStringToConvert[i] != sortStringToConvert[i + 1])
            {
                theNumberOfCharactersSmallerGiven.Add(sortStringToConvert[i + 1], i + 1);
            }
        }

        // Предпоследний символ строки стоит во входной строке на той же позиции что и строка начинающаяся с последнего символа входной строки в таблице сдвигов
        // Строка n  в таблице 1 2 3 ... n - находится на позиции = k + l, где k - количество символов равных n, но стоящих раньше во входной строке,
        // т.к. префикс этих строк меньше и в отсортированной таблице они будут стоять раньше. l - количество символов, меньших n. Знаем n[length - 1]
        // Нашли n[length - 2], найдем n[length - 3] ...
        var answer = new char[stringToConvert.Length];
        answer[answer.Length - 1] = stringToConvert[index];
        for (int i = answer.Length - 1; i > 0; i--)
        {
            int number = theNumberOfCharactersEqualGivenAndStandingHigher[index];
            int secondNumber = theNumberOfCharactersSmallerGiven[stringToConvert[index]];
            index = number + secondNumber;
            answer[i - 1] = stringToConvert[index];
        }

        return new String(answer);
    }
}