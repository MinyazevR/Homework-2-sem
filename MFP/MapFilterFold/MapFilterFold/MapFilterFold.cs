using System;
using System.Collections.Generic;

namespace MFP;

/// <summary>
/// Class representing the Map, Filter, Fold functions
/// </summary>
public static class MapFilterFold
{
    /// <summary>
    /// Map accepts a list and a function that transforms a list item
    /// </summary>
    /// <typeparam name="T">Type of items in the initial list</typeparam>
    /// <typeparam name="TR">Type of return value of the passed function</typeparam>
    /// <param name="list">Passsed list</param>
    /// <param name="func">Passed function</param>
    /// <returns>The list obtained by applying the passed function to each element of the passed list</returns>
    public static List<TR> Map<T, TR>(List<T> list, Func<T, TR> func)
    {
        var result = new List<TR>();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(func(list[i]));
        }

        return result;
    }

    /// <summary>
    /// Function that returns a new list consisting of those list elements that give the value true in the Boolean function func
    /// </summary>
    /// <typeparam name="T">Type of items in the list</typeparam>
    /// <param name="list">Passed list</param>
    /// <param name="func">Passed function</param>
    /// <returns>List made up of those elements of the passed list for which the passed function returned true</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> func)
    {
        var result = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            if (func(list[i]))
            {
                result.Add(list[i]);
            }
        }

        return result;
    }

    /// </summary>
    /// <typeparam name="T">The type of values in the initial list</typeparam>
    /// <typeparam name="TR">The type of initial value</typeparam>
    /// <param name="list">Passed list</param>
    /// <param name="initialValue">Initial value</param>
    /// <param name="func">function that takes the current accumulated value 
    /// and the current list item, and returns the next accumulated value</param>
    /// <returns>Fold returns the accumulated value obtained after the entire passage of the list</returns>
    public static TR Fold<T, TR>(List<T> list, TR initialValue, Func<TR, T, TR> func)
    {
        for (int i = 0; i < list.Count; i++)
        {
            initialValue = func(initialValue, list[i]);
        }

        return initialValue;
    }
}
