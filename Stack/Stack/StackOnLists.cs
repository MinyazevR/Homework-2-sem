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
public class StackOnLists<T> : IStack<T>
{
    private class StackElement
    {
        private StackElement? next { get; set; }
        private T? value;
        public T? Value { get => value; set { } }
        public StackElement? Next { get => next; set { } }
        public StackElement(T value, StackElement? next)
        {
            this.value = value;
            this.next = next;
        }
    }
    private StackElement? head;
    private int numberOfElements;

    /// <summary>
    /// Function for checking the stack for emptiness
    /// </summary>
    /// <returns> True - if the stack is empty </returns>
    public override bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    /// <summary>
    /// Function for adding an element to the stack
    /// </summary>
    /// <param name="value"> The value to add</param>
    public override void Push(T value)
    {
        numberOfElements++;
        head = new StackElement(value, head);
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public override T? Pop()
    {
        try
        {
            if (head == null)
            {
                throw new StackException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }
        if (head != null)
        {
            T? value = head.Value;
            head = head.Next;
            numberOfElements--;
            return value;
        }
        return default(T);
    }

    /// <summary>
    /// Function that returns the number of elements in the stack
    /// </summary>
    /// <returns>Number of elements in stack</returns>
    public override int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public override T? ReturnTopOfTheStack()
    {
        try
        {
            if (head == null)
            {
                throw new StackException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }
        if (head != null)
        {
            return head.Value;
        }
         return default(T);
    }

    /// <summary>
    /// Function for stack printing
    /// </summary>
    public override void PrintStack()
    {
        if (head == null)
        {
            return;
        }
        StackElement copyHead = head;
        while (copyHead != null && copyHead.Next != null)
        {
            Console.Write($"{copyHead.Value} ");
            copyHead = copyHead.Next;
        }
        if (copyHead != null && copyHead.Value != null)
        {
            Console.Write($"{copyHead.Value} ");
        }
    }
}