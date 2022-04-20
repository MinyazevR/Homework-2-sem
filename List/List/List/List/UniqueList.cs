namespace List;

/// <summary>
/// Class representing a list of unique values
/// </summary>
public class UniqueList<T> : SinglyLinkedList<T>
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
    public override bool Remove(int index)
    {
        if (!base.Remove(index))
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
    public override bool RemoveAt(T value)
    {
        if (!base.RemoveAt(value))
        {
            throw new RemoveNonExistingElementException();
        }

        return false;
    }
}
