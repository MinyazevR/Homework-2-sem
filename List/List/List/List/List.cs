namespace List;

using System;
using System.Collections.Generic;

/// <summary>
/// Сlass representing a list
/// </summary>
/// <typeparam name="T"> type of item values in the list </typeparam>
public class SinglyLinkedList<T> where T : IComparable<T>
{
    /// <summary>
    /// Class for storing list items
    /// </summary>
    private class ListElement
    {
        public T? Value { get ; set; }
        public ListElement? Next { get; set; }
    }

    private ListElement? head;
    private ListElement? tail;

    /// <summary>
    /// List size
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Function for adding an item to a list
    /// </summary>
    /// <param name="value">T ype of item value in the list</param>
    public virtual void Add(T value)
    {
        if (value == null)
        {
            return;
        }

        Size++;
        if (head == null || tail == null)
        {
            head = new ListElement();
            tail = head;
            head.Value = value;
            return;
        }

        var newTail = new ListElement();
        newTail.Value = value;
        tail.Next = newTail;
        tail = newTail;
    }

    /// <summary>
    /// Function to remove an item from the list
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <returns>was the item in the list</returns>
    public virtual bool RemoveAt(int index)
    {
        if (index >= Size || index < 0)
        {
            return false;
        }

        Size--;
        if (index == 0)
        {
            head = head?.Next;
            return true;
        }

        var element = head;
        ListElement? copyElement = null;

        for (int i = 0; i < index - 1; i++)
        {
            if (i == index - 1)
            {
                copyElement = element;
            }

            element = element?.Next;
        }

        if (element != null && copyElement != null)
        {
            copyElement.Next = element.Next;
            element.Next = null;
        }

        return true;
    }

    /// <summary>
    /// Function to remove an item from the list
    /// </summary>
    /// <param name="value">Value to be deleted</param>
    /// <returns>was the value in the list</returns>
    public virtual bool Remove(T value)
    {
        var copyHead = head;
        for (int i = 0; i < Size; i++)
        {
            while (copyHead!= null)
            {
                if (copyHead != null && value != null && value.Equals(copyHead.Value))
                {
                    RemoveAt(i);
                    return true;
                }

                copyHead = copyHead?.Next;
            }
        }

        return false;
    }

    /// <summary>
    /// Function for changing the value of an element by index
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <param name="value">New value</param>
    public virtual bool ChangeElement(int index, T value)
    {
        if (index >= Size || index < 0)
        {
            return false;
        }

        var element = head;
        for (int i = 0; i < index - 1; i++)
        {
            element = element?.Next;
        }

        if (element != null)
        {
            element.Value = value;
        }

        return true;
    }

    /// <summary>
    /// Function for printing a list
    /// </summary>
    public void PrintList()
    {
        var element = head;
        while (element != null)
        {
            Console.Write($"{element.Value} ");
            element = element.Next;
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Function to search for an item in the list
    /// </summary>
    /// <param name="value">Search value</param>
    /// <returns>Is there an item in the list</returns>
    public bool Contains(T value)
    {
        var element = head;
        while (element != null)
        {
            if (value != null && value.CompareTo(element.Value) == 0)
            {
                return true;
            }

            element = element.Next;
        }

        return false;
    }

    /// <summary>
    /// Function for clear list
    /// </summary>
    public void ClearList() => head = null;

    public T GetItemByIndex(int index)
    {
        if (index >= Size || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        ListElement? element = head;
        for (int i = 0; i < index; i++)
        {
            element = element?.Next;
        }

        return element!.Value!;
    }

}