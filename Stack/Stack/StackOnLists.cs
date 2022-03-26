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
        public T? Value { get => value; set { this.value = value; } }
        public StackElement? Next { get => next; set { next = value; } }
    }

    private StackElement? head;
    private int numberOfElements;

    /// <summary>
    /// Function for checking the stack for emptiness
    /// </summary>
    /// <returns> True - if the stack is empty </returns>
    public override bool IsEmpty() => numberOfElements == 0;

    /// <summary>
    /// Function for adding an element to the stack
    /// </summary>
    /// <param name="value"> The value to add</param>
    public override void Push(T value)
    {
        numberOfElements++;
        StackElement newHead = new StackElement();
        newHead.Value = value;
        newHead.Next = head;
        head = newHead;
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public override T? Pop()
    {
        if (head == null)
        {
            throw new StackException("Stack is empty");
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
    public override int ReturnNumberOfElements() => numberOfElements;

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public override T? ReturnTopOfTheStack()
    {
        if (head == null)
        {
            throw new StackException("Stack is empty");
        }
        return head == null ? default(T) : head.Value;
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
    public override void DeleteStack() => head = null;
}