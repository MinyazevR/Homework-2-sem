using System;
using System.Collections.Generic;

namespace Stack;

public class StackOnLists<T>
{
    private StackOnLists<T>? head;
    private StackOnLists<T>? next;
    private T? value;
    private int numberOfElements;

    public bool IsEmpty()
    {
        return numberOfElements == 0;
    }

    public void Push(T value)
    {
        numberOfElements++;
        StackOnLists<T> newHead = new StackOnLists<T>();
        newHead.next = head;
        head = newHead;
        head.value = value;
    }

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

    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    public T ReturnTopOfTheStack()
    {
        if (head == null || head.value == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return head.value;
    }

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
