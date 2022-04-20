namespace Stack;

using System;

/// <summary>
/// A class representing the stack on arrays
/// </summary>
public class StackOnArray<T> : IStack<T>
{
    private T[] values;
    private int numberOfElements;

    public StackOnArray()
    {
        values = new T[20];
    }

    /// <summary>
    /// Function for checking the stack for emptiness
    /// </summary>
    /// <returns> True - if the stack is empty </returns>
    public bool IsEmpty() => numberOfElements == 0;

    /// <summary>
    /// Function for adding an element to the stack
    /// </summary>
    /// <param name="value"> The value to add</param>
    public void Push(T value)
    {
        if (values != null && numberOfElements == values.Length)
        {
            Array.Resize(ref values, values.Length + 20);
        }

        numberOfElements++;
        if (values == null)
        {
            return;
        }

        values[numberOfElements - 1] = value;
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public T Pop()
    {
        if (numberOfElements == 0 || values == null)
        {
            throw new StackIsEmptyException();
        }

        T topOfSTack = values[numberOfElements - 1];
        Array.Clear(values, numberOfElements - 1, 1);
        numberOfElements--;
        return topOfSTack;
    }

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public T TopOfTheStack()
    {
        if (numberOfElements == 0 || values == null)
        {
            throw new StackIsEmptyException();
        }

        return values[numberOfElements - 1];
    }

    /// <summary>
    /// Function that returns the number of elements in the stack
    /// </summary>
    /// <returns>Number of elements in stack</returns>
    public int NumberOfElements() => numberOfElements;

    /// <summary>
    /// Function for stack printing
    /// </summary>
    public void PrintStack()
    {
        for (int i = numberOfElements - 1; i >= 0; i--)
        {
            if (values != null)
            {
                Console.Write($"{values[i]} ");
            }
        }
    }

    /// <summary>
    /// Function for removing the stack
    /// </summary>
    public void ClearStack() => values = new T[20];
}
