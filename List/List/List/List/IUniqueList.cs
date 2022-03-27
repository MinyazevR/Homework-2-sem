namespace List;

/// <summary>
/// Class interface for a unique list
/// </summary>
/// <typeparam name="T">Еype of items in the list</typeparam>
public interface IUniqueList<T>
{
    /// <summary>
    /// Function for changing the value of an element by index
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <param name="value">New value</param>
    public bool ChangeElement(int index, T value);

    /// <summary>
    /// Function for printing a list
    /// </summary>
    public void PrintList();

    /// <summary>
    /// Аunction to search for an item in the list
    /// </summary>
    /// <param name="value">Search value</param>
    /// <returns>Is there an item in the list</returns>
    public bool Contains(T value);

    /// <summary>
    /// Function for deleting a list
    /// </summary>
    public void DeleteList();

    /// <summary>
    /// Function for adding an item to a list
    /// </summary>
    /// <param name="value">Type of item value in the list</param>
    public void Add(T value);

    /// <summary>
    /// Function to remove an item from the unique list
    /// </summary>
    /// <param name="index">Item position in the list</param>
    public bool Remove(int index);

    /// <summary>
    /// Function for return number of element on list
    /// </summary>
    /// <returns>Number of element on list</returns>
    public int ReturnSize();
}

public class Solution
{
    public static void Main(string[] args)
    {
    }
}