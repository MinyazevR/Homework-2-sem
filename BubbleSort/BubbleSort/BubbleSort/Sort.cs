namespace Sort;

using System;
using System.Collections.Generic;

public class Sort
{
    public static List<T> BubbleSort<T>(List<T> listOfObjects, IComparer<T> comparator)
    {
        for (int i = 0; i < listOfObjects.Count - 1; i++)
        {
            for (int j = listOfObjects.Count - 1; j > i; j--)
            {
                if (comparator.Compare(listOfObjects[j - 1], listOfObjects[j]) > 0)
                {
                    (listOfObjects[j - 1], listOfObjects[j]) = (listOfObjects[j], listOfObjects[j - 1]);
                }
            }
        }
        return listOfObjects;
    }
}
