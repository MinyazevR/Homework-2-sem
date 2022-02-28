using System;

namespace Sort;
public class BubbleSort
{
    public static void BubbleSortArray(int[] arrayOfNumbers)
    {
        for (int i = 0; i < arrayOfNumbers.Length - 1; i++)
        {
            for (int j = arrayOfNumbers.Length - 1; j > i; j--)
            {
                if (arrayOfNumbers[j - 1] > arrayOfNumbers[j])
                {
                    (arrayOfNumbers[j - 1], arrayOfNumbers[j]) = (arrayOfNumbers[j], arrayOfNumbers[j - 1]);
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов в массиве");
        var inputString = Console.ReadLine();
        int numberOfElementsInArray = int.Parse(inputString);
        var random = new Random();
        var arrayOfNumbers = new int[numberOfElementsInArray];
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = random.Next(15);
            Console.Write($"{arrayOfNumbers[i]} ");
        }
        BubbleSortArray(arrayOfNumbers);
        Console.WriteLine();
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            Console.Write($"{arrayOfNumbers[i]} ");
        }
    }
}
