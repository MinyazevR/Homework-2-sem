using System;
using System.Collections.Generic;

namespace MFP;

/// <summary>
/// Class representing the Map, Filter, Fold functions
/// </summary>
public static class MFP
{
    /// <summary>
    /// Map accepts a list and a function that transforms a list item
    /// </summary>
    /// <typeparam name="T">Type of items in the list</typeparam>
    /// <param name="list">Passsed list</param>
    /// <param name="func">Passed function</param>
    /// <returns>The list obtained by applying the passed function to each element of the passed list</returns>
    public static List<T> Map<T>(List<T> list, Func<T, T> func)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = func(list[i]);
        }
        return list;
    }

    /// <summary>
    /// Function that returns a boolean value for a list item.
    /// </summary>
    /// <typeparam name="T">Type of items in the list</typeparam>
    /// <param name="list">Passed list</param>
    /// <param name="func">Passed function</param>
    /// <returns>List made up of those elements of the passed list for which the passed function returned true.</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> func)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            if (func(list[i]))
            {
                result.Add(list[i]);
            }
        }
        return result;
    }

    /// <summary>
    /// Fold takes a list, an initial value, and a function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">Passed list</param>
    /// <param name="initialValue">Initial value</param>
    /// <param name="func">function that takes the current accumulated value 
    /// and the current list item, and returns the next accumulated value</param>
    /// <returns>Fold returns the accumulated value obtained after the entire passage of the list</returns>
    public static T Fold<T>(List<T> list, T initialValue, Func<T, T, T> func)
    {
        for (int i = 0; i < list.Count; i++)
        {
            initialValue = func(initialValue, list[i]);
        }
        return initialValue;
    }
}

public class Solution
{
    static void Main(string[] args)
    {
    }
}
