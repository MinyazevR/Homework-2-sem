using System;
using System.Collections.Generic;

namespace Stack;

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
        if(numberOfElements == values.Length)
        {
            Array.Resize(ref values, values.Length + 20);
        }
        numberOfElements++;
        values[numberOfElements - 1] = value;
    }

    /// <summary>
    /// Function for removing an element from the stack
    /// </summary>
    /// <returns> Remote value</returns>
    public override T Pop()
    {
        try
        {
            if (numberOfElements == 0)
            {
                throw new StackException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }
        T topOfSTack = values[numberOfElements - 1];
        numberOfElements--;
        return topOfSTack;
    }

    /// <summary>
    /// Function that returns the top of the stack
    /// </summary>
    /// <returns>Top of the stack</returns>
    public override T ReturnTopOfTheStack()
    {
        try
        {
            if (numberOfElements == 0)
            {
                throw new StackException("Stack is empty");
            }
        }
        catch (StackException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }
        return values[numberOfElements - 1]; 
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
    /// Function for stack printing
    /// </summary>
    public override void PrintStack()
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            Console.Write($"{values[i]} ");
        }
    }
}