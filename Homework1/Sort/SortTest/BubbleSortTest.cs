using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System;

namespace SortTest
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arrayOfNumbers = new int[100];
            BubbleSort array = new BubbleSort();
            array.BubbleSortArray(arrayOfNumbers);
            int flag = 1;
            for (int i = 1; i < arrayOfNumbers.Length; i++)
            {
                if(arrayOfNumbers[i] < arrayOfNumbers[i - 1])
                {
                    flag = 0;
                    break;
                }
            }
            Assert.AreEqual(flag, 1);
        }
    }
}
