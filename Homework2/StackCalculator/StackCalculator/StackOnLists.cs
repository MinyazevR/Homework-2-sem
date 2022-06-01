namespace Stack;

using System;

/// <summary>
/// A class representing the stack on lists
/// </summary>
public class StackOnLists<T> : IStack<T>
{
    private class StackElement
    {
        public StackElement? Next { get; set; }
        public T? Value { get; set; }
    }

    private StackElement? head;
    private int numberOfElements;

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
        numberOfElements++;
        StackElement newHead = new();
        newHead.Value = value;
        newHead.Next = head;
        head = newHead;
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public T? Pop()
    {
        if (head == null)
        {
            throw new StackIsEmptyException();
        }

        if (head != null)
        {
            T? value = head.Value;
            head = head.Next;
            numberOfElements--;
            return value;
        }
        return default;
    }

    /// <summary>
    /// Function that returns the number of elements in the stack
    /// </summary>
    /// <returns>Number of elements in stack</returns>
    public int NumberOfElements() => numberOfElements;

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public T? TopOfTheStack()
    {
        if (head == null)
        {
            throw new StackIsEmptyException();
        }
        return head == null ? default : head.Value;
    }

    /// <summary>
    /// Function for stack printing
    /// </summary>
    public void PrintStack()
    {
        if (head == null)
        {
            return;
        }

        StackElement? copyHead = head;
        while (copyHead != null)
        {
            Console.Write($"{copyHead.Value} ");
            copyHead = copyHead.Next;
        }
    }

    /// <summary>
    /// Function for removing the stack
    /// </summary>
    public void ClearStack() => head = null;
}
