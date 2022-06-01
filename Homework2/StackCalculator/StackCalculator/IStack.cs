namespace Stack;

/// <summary>
/// A class representing the stack interface
/// </summary>
public interface IStack<T>
{
    /// <summary>
    /// Function for checking the stack for emptiness
    /// </summary>
    /// <returns> True - if the stack is empty </returns>
    public bool IsEmpty();

    /// <summary>
    /// Function for adding an element to the stack
    /// </summary>
    /// <param name="value"> The value to add</param>
    public void Push(T value);

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public T? Pop();

    /// <summary>
    /// Function that returns the number of elements in the stack
    /// </summary>
    /// <returns>Number of elements in stack</returns>
    public int NumberOfElements();

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public T? TopOfTheStack();

    /// <summary>
    /// Function for stack printing
    /// </summary>
    public void PrintStack();

    /// <summary>
    /// Function for removing the stack
    /// </summary>
    public void ClearStack();
}
