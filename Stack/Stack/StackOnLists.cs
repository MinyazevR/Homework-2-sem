using System;
using System.Collections.Generic;

namespace Stack;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class StackException : Exception
{
    public StackException(string? message) : base(message){}
}

/// <summary>
/// A class representing the stack on lists
/// </summary>
public class StackOnLists<T>
{
    private class StackElement
    {
        private StackElement? Next { get; set; }
        private T? value;
        public T? publicValue { get => value; set { } }
        public StackElement? publicNext { get => Next; set { } }
        public StackElement(T value, StackElement? next)
        {
            this.value = value;
            this.Next = next;
        }
    }
    private StackElement? head;
    private int numberOfElements;

    /// <summary>
    /// Function for checking the stack for emptiness
    /// </summary>
    /// <returns> True - if the stack is empty </returns>
    public bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    /// <summary>
    /// Function for adding an element to the stack
    /// </summary>
    /// <param name="value"> The value to add</param>
    public void Push(T value)
    {
        numberOfElements++;
        head = new StackElement(value, head);
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public T? Pop()
    {
        try
        {
            if (head == null)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        if (head != null)
        {
            T? value = head.publicValue;
            head = head.publicNext;
            numberOfElements--;
            return value;
        }
        return default(T);
    }

    /// <summary>
    /// Function that returns the number of elements in the stack
    /// </summary>
    /// <returns>Number of elements in stack</returns>
    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public T? ReturnTopOfTheStack()
    {
        try
        {
            if (head == null)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        if (head != null)
        {
            return head.publicValue;
        }
         return default(T);
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
        StackElement copyHead = head;
        while (copyHead != null && copyHead.publicNext != null)
        {
            Console.Write($"{copyHead.publicValue} ");
            copyHead = copyHead.publicNext;
        }
        if (copyHead != null && copyHead.publicValue != null)
        {
            Console.Write($"{copyHead.publicValue} ");
        }
    }
}

public class Solution
{
    static void Main()
    {
        return;
    }
}