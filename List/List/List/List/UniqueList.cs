namespace List;

/// <summary>
/// Class representing a list of unique values
/// </summary>
/// <typeparam name="T"></typeparam>
public class UniqueList<T> : SinglyLinkedList<T>
{
    /// <summary>
    /// Function for adding an item to a list
    /// </summary>
    /// <param name="value">Type of item value in the list</param>
    public override void Add(T value)
    {
        try
        {
            if (Contains(value))
            {
                throw new RepeatValueException("this value already exist in list");
            }
        }
        catch (RepeatValueException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            throw;
        }
        base.Add(value);
    }

    /// <summary>
    /// Function to remove an item from the unique list
    /// </summary>
    /// <param name="index">Item position in the list</param>
    public override bool Remove(int index)
    {
        try
        {
            if (!base.Remove(index))
            {
                throw new RemoveNonExistenElementException("this item does not exist in the list");
            }
        }
        catch (RemoveNonExistenElementException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            throw;
        }
        return true;
    }
}
