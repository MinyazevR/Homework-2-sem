namespace Queue;

using System.Collections.Generic;

/// <summary>
/// Сlass representing a Queque
/// </summary>
/// <typeparam name="T"> type of item values in the queque </typeparam>
public class Queue<T>
{
    /// <summary>
    /// Class for storing queque items
    /// </summary>
    private class QueueElement
    {
        public T? Value { get; set; }
        public int Priority { get; set; }
        public QueueElement? Next { get; set; }

        public QueueElement(T value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
        }

        public QueueElement(){ }
    }

    private QueueElement? head;
    private int size; 

    /// <summary>
    /// Function for adding an item to queque
    /// </summary>
    /// <param name="value">value</param>
    /// <param name="priority">priority</param>
    public void Enqueue(T value, int priority)
    {
        if (value == null)
        {
            return;
        }

        size++;
        if (head == null)
        {
            head = new(value, priority);
            return;
        }

        if (head.Priority < priority)
        {
            QueueElement newHead = new(value, priority);
            newHead.Next = head;
            head = newHead; 
            return;
        }

        QueueElement? copyHead = head;
        QueueElement? element = new();
        while (copyHead != null)
        {
            if (copyHead.Priority >= priority && copyHead.Next !=null)
            {
                element = copyHead;
                copyHead = copyHead.Next;
            }
            else
            {
                QueueElement newElement = new(value, priority);
                newElement.Next = element.Next;
                element.Next = newElement;
                return;
            }
        }

        QueueElement newTail = new(value, priority);
        element.Next = newTail;
    }

    /// <summary>
    /// Function to remove the highest priority element from the queue
    /// </summary>
    public T Dequeue()
    {
        if (head == null || head.Value == null)
        {
            throw new EmptyQueueException();
        }

        size--;
        T headValue = head.Value;
        head = head.Next;
        return headValue;
    }


    public bool IsEmpty() => size == 0;
}
