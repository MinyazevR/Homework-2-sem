using System;
using System.Collections.Generic;

namespace Stack;

public class PersonException : Exception
{
    public PersonException(string? message) : base(message){}
}

// A class representing the stack on lists
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
    // Function for checking the stack for emptiness
    public bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    // Function for adding an element to the stack
    public void Push(T value)
    {
        numberOfElements++;
        head = new StackElement(value, head);
    }

    // Function for removing an element from the stack
    public T? Pop()
    {
        try
        {
            if (head == null)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (PersonException ex)
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

    // Function that returns the number of elements in the stack
    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    // Function that returns the top of the stack
    public T? ReturnTopOfTheStack()
    {
        try
        {
            if (head == null)
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        catch (PersonException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        if (head != null)
        {
            return head.publicValue;
        }
         return default(T);
    }

    // Function for stack printing
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