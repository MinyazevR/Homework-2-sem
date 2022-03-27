using System;
using System.Collections.Generic;

namespace List;

/// <summary>
/// Сlass representing a list
/// </summary>
/// <typeparam name="T"> type of item values in the list </typeparam>
abstract public class SinglyLinkedList<T> : IUniqueList<T>
{
    /// <summary>
    /// Class for storing list items
    /// </summary>
    private class ListElement
    {
        private ListElement? next { get; set; }
        private T? value;
        public T? Value { get => value; set { this.value = value; } }
        public ListElement? Next { get => next; set { next = value; } }
    }

    private ListElement? head;
    private ListElement? tail;
    private int size;

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
        size++;
        if (head == null || tail == null)
        {
            head = new ListElement();
            tail = head;
            head.Value = value;
            return;
        }
        ListElement newHead = new ListElement();
        newHead.Value = value;
        tail.Next = newHead;
        tail = newHead;
    }

    /// <summary>
    /// Function to remove an item from the list
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <returns>was the item in the list</returns>
    public virtual bool Remove(int index)
    {
        if (index > size || index <= 0)
        {
            return false;
        }
        size--;
        if (index == 1)
        {
            head = head?.Next;
            return true;
        }
        ListElement? element = new ListElement();
        ListElement? copyElement = new ListElement();
        element = head;
        for ( int i = 1; i < index; i++)
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
    /// Function for changing the value of an element by index
    /// </summary>
    /// <param name="index">Item position in the list</param>
    /// <param name="value">New value</param>
    public bool ChangeElement(int index, T value)
    {
        if (index > size || index <= 0)
        {
            return false;
        }
        ListElement? element = new ListElement();
        element = head;
        for (int i = 1; i < index; i++)
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
        ListElement? element = new ListElement();
        element = head;
        while (element != null)
        {
            Console.Write($"{element.Value} ");
            element = element.Next;
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Аunction to search for an item in the list
    /// </summary>
    /// <param name="value">Search value</param>
    /// <returns>Is there an item in the list</returns>
    public bool Contains(T value)
    {
        ListElement? element = new ListElement();
        element = head;
        while (element != null)
        {
            if (value != null && value.Equals(element.Value))
            {
                return true;
            }
            element = element.Next;
        }
        return false;
    }

    /// <summary>
    /// Function for deleting a list
    /// </summary>
    public void DeleteList()
    {
        while (head != null)
        {
            ListElement? element = head;
            head = head.Next;
            element = null;
        }
    }

    /// <summary>
    /// Function for return number of element on list
    /// </summary>
    /// <returns>Number of element on list</returns>
    public int ReturnSize() => size;
}