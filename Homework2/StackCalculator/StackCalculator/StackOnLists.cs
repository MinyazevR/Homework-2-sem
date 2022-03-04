using System;
using System.Collections.Generic;

namespace Stack;

// A class representing the stack on lists
public class StackOnLists<T>
{
    private class StackElement
    {
        private StackElement? Next { get; set; }
        private T? value;
        public T? publicValue{ get => value; set{} }
        public StackElement? publicNext{ get => Next; set { } }
        public StackElement(T value, StackElement? next)
        {
            this.value = value;
            this.Next = next;
        }
        public StackElement(StackElement? head)
        {
            head = head?.Next;
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
        if (head == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T? value = head.publicValue;
        head = head.publicNext;
        numberOfElements--;
        return value;
    }

    // Function that returns the number of elements in the stack
    public int ReturnNumberOfElements()
    {
        return numberOfElements;
    }

    // Function that returns the top of the stack
    public T? ReturnTopOfTheStack()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return head.publicValue;
    }

    // Function for stack printing
    public void PrintStack()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Stack is empty");
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
