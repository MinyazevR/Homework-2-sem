using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System;
namespace SortTest;

[TestClass]
public class BubbleSortTest
{
    private static void CheckSort(int[] arrayOfNumbers)
    {
        BubbleSort.BubbleSortArray(arrayOfNumbers);
        for (int i = 1; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] < arrayOfNumbers[i - 1])
            {
                Assert.Fail();
            }
        }
    }

    [TestMethod]
    public void CheckSortArrayOfEqualNumbers()
    {
        int[] arrayOfNumbers = new int[100];
        for (int i = 1; i < arrayOfNumbers.Length; i++)
        {
           arrayOfNumbers[i] = 12;
        }
        BubbleSort.BubbleSortArray(arrayOfNumbers);
        CheckSort(arrayOfNumbers);
    }

    [TestMethod]
    public void CheckSortOfSortedArray()
    {
        int[] arrayOfNumbers = new int[100];
        for (int i = 1; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = i;
        }
        CheckSort(arrayOfNumbers);
    }

    [TestMethod]
    public void CheckSortOfEmptyArray()
    {
        int[] arrayOfNumbers = Array.Empty<int>();
        CheckSort(arrayOfNumbers);
    }
}

