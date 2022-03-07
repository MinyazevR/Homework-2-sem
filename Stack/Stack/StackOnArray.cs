using System;
using System.Collections.Generic;

namespace Stack;

// A class representing the stack on arrays
public class StackOnArray<T>
{
    private T[] values;
    private int numberOfElements;

    public StackOnArray()
    {
        values = new T[20];
    }

    // Function for checking the stack for emptiness
    public bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    // Function for adding an element to the stack
    public void Push(T value)
    {
        if(numberOfElements == values.Length)
        {
            Array.Resize(ref values, values.Length + 20);
        }
        numberOfElements++;
        values[numberOfElements - 1] = value;
    }

    // Function for removing an element from the stack
    public T Pop()
    {
        try
        {
            if (numberOfElements == 0)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (PersonException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        T topOfSTack = values[numberOfElements - 1];
        numberOfElements--;
        return topOfSTack;
    }

    // Function that returns the top of the stack
    public T ReturnTopOfTheStack()
    {
        try
        {
            if (numberOfElements == 0)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (PersonException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        return values[numberOfElements - 1]; 
    }

    // Function that returns the number of elements in the stack
    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    // Function for stack printing
    public void PrintStack()
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            Console.Write($"{values[i]} ");
        }
    }
}