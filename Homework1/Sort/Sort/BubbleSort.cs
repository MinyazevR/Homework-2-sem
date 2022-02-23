using System;

namespace Sort
{
    public class BubbleSort
    {
        public void BubbleSortArray(int[] arrayOfNumbers)
        {
            for (int i = 0; i < arrayOfNumbers.Length - 1; i++)
            {
                for (int j = arrayOfNumbers.Length - 1; j > i; j--)
                {
                    if (arrayOfNumbers[j - 1] > arrayOfNumbers[j])
                    {
                        int temporary = arrayOfNumbers[j];
                        arrayOfNumbers[j] = arrayOfNumbers[j - 1];
                        arrayOfNumbers[j - 1] = temporary;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов в массиве");
            var inputString = Console.ReadLine();
            int numberOFElementsInArray = int.Parse(inputString);
            int[] arrayOfNumbers = new int[numberOFElementsInArray];
            for(int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Random random = new Random();
                arrayOfNumbers[i] = random.Next() % 15;
                Console.Write("{0} ", arrayOfNumbers[i]);
            }
            BubbleSort array = new BubbleSort();
            array.BubbleSortArray(arrayOfNumbers);
            Console.WriteLine();
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Console.Write("{0} ", arrayOfNumbers[i]);
            }
        }
    }
}
