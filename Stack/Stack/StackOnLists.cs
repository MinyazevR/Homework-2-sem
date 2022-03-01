using System;
using System.Collections.Generic;

namespace Stack;

// A class representing the stack
public class StackOnLists<T>
{
    private StackOnLists<T>? head;
    private StackOnLists<T>? next;
    private T? value;
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
        StackOnLists<T> newHead = new StackOnLists<T>();
        newHead.next = head;
        head = newHead;
        head.value = value;
    }

    // Function for removing an element from the stack
    public T Pop()
    {
        if (head == null || head.value == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var topOfSTack = head;
        head = head.next;
        numberOfElements--;
        return topOfSTack.value;
    }

    // Function that returns the number of elements in the stack
    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    // Function that returns the top of the stack
    public T ReturnTopOfTheStack()
    {
        if (head == null || head.value == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return head.value;
    }

    // Function for stack printing
    public void PrintStack()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        StackOnLists<T> copyHead = head;
        while (copyHead != null && copyHead.next != null)
        {
            Console.Write($"{copyHead.value} ");
            copyHead = copyHead.next;
        }
        if (copyHead != null && copyHead.value != null)
        {
            Console.Write($"{copyHead.value} ");
        }
    }
}
