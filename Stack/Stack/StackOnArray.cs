using System;
using System.Collections.Generic;

namespace Stack;

public class StackOnArray<T>
{
    private T[] values;
    private int numberOfElements;

    public StackOnArray()
    {
        values = new T[20];
    }

    public bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    public void Push(T value)
    {
        if(numberOfElements == values.Length)
        {
            Array.Resize(ref values, values.Length + 20);
        }
        numberOfElements++;
        values[numberOfElements - 1] = value;
    }

    public T Pop()
    {
        if(numberOfElements == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T topOfSTack = values[numberOfElements - 1];
        numberOfElements--;
        return topOfSTack;
    }

    public T ReturnTopOfTheStack()
    { 
        return values[numberOfElements - 1]; 
    }

    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    public void PrintStack()
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            Console.Write($"{values[i]} ");
        }
    }
}