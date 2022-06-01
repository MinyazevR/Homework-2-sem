namespace List;

/// <summary>
/// Class representing a list of unique values
/// </summary>
public class UniqueList<T> : SinglyLinkedList<T> where T : IComparable<T>
{
    /// <summary>
    /// Function for adding an item to a list
    /// </summary>
    /// <param name="value">Type of item value in the list</param>
    public override void Add(T value)
    {
        if (Contains(value))
        {
            throw new RepeatValueException();
        }

        base.Add(value);
    }

    /// <summary>
    /// Function to remove an item from the unique list
    /// </summary>
    /// <param name="index">Item position in the list</param>
    public override bool RemoveAt(int index)
    {
        if (!base.RemoveAt(index))
        {
            throw new RemoveNonExistingElementException();
        }

        return true;
    }

    /// <summary>
    /// Function to remove an item from the list
    /// </summary>
    /// <param name="value">Value to be deleted</param>
    /// <returns>was the value in the list</returns>
    public override bool Remove(T value)
    {
        if (!base.Remove(value))
        {
            throw new RemoveNonExistingElementException();
        }

        return false;
    }

    /// <summary>
    /// Function for changing the value of an element by index
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <param name="value">New value</param>
    public override bool ChangeElement(int index, T value)
    {
        if (index >= Size || index < 0)
        {
            return false;
        }

        if (base.GetItemByIndex(index).CompareTo(value) == 0)
        {
            return true;
        }

        if (Contains(value))
        {
            throw new InvalidOperationException();
        }

        base.ChangeElement(index, value);
        return true;
    }
}
