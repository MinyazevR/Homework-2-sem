namespace SkipList;

using System.Collections;

// A class representing a skip list
public class SkipList<T> : IList<T> where T : IComparable<T>
{

    /// <summary>
    /// Class for storing list items
    /// </summary>
    private class ListElement
    {
        public T? Value { get; set; }
        public ListElement? Next { get; set; }
        public ListElement? Down { get; set; }
    }

    public SkipList()
    {
        heads.Add(new());
    }

    private readonly List<ListElement> heads = new();

    public bool IsReadOnly { get; }

    public bool IsFixedSize { get; }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int counter = 0;
            ListElement element = heads[0].Next!;
            while (counter != index)
            {
                element = element.Next!;
                counter++;
            }

            return element.Value!;
        }
        set => throw new NotSupportedException();
    }

    // A function that returns true with a probability of 0.5
    // (maybe not with a probability of 0.5,
    // but in a naive solution we will assume that with a probability of 0.5)
    private static bool SuccessfulOutcome(Random random)
    {
        if (random.Next(100) < 50)
        {
            return true;
        }

        return false;
    }

    // Function for building a new level based on the old one
    private void BuildLevel(ListElement newHead)
    {
        newHead.Down = heads[^1];

        ListElement? newNode = heads[^1].Next?.Next;

        ListElement currentNode = newHead;

        while (newNode != null && newNode.Next != null)
        {
            currentNode.Next = CreateNode(newNode.Value, newNode, currentNode.Next);
            newNode = newNode.Next.Next;
        }
    }

    // Function for creating a new node
    private static ListElement CreateNode(T? item, ListElement? downNode, ListElement? nextNode)
    {
        ListElement node = new();
        node.Next = nextNode;
        node.Value = item;
        node.Down = downNode;
        return node;
    }

    public void Add(T item)
    {
        if (heads[^1].Next != null)
        {
            UpdateLevel();
        }
        else if (heads[^1].Next == null && Count > 1)
        {
            heads.RemoveAt(heads.Count - 1);
        }

        Count++;
        RecursiveAdd(item, new(), heads[^1]);
    }

    // Function for adding an item to a list
    private static ListElement? RecursiveAdd(T item, Random random, ListElement element)
    {
        while (element.Next != null && element.Next.Value!.CompareTo(item) < 0)
        {
            element = element.Next;
        }

        ListElement? downNode;

        if (element.Down == null)
        {
            downNode = null;
        }

        else
        {
            downNode = RecursiveAdd(item, random, element.Down);
        }

        if (downNode != null || element.Down == null)
        {
            element.Next = CreateNode(item, downNode, element.Next);
            if (SuccessfulOutcome(random))
            {
                return element.Next;
            }
        }

        return null;
    }

    public bool Contains(T item)
    {
        if (heads.Count == 0)
        {
            return false;
        }

        return RecursiveFind(heads[^1], item).Value!.CompareTo(item) == 0;
    }

    // Function for finding an item in a list
    private static ListElement RecursiveFind(ListElement node, T item)
    {
        while (node.Next != null && node.Next.Value!.CompareTo(item) < 0)
        {
            node = node.Next;
        }

        if (node.Next != null && node.Next.Value!.CompareTo(item) == 0)
        {
            return node.Next;
        }

        if (node.Down == null)
        {
            return node;
        }

        return RecursiveFind(node.Down, item);
    }


    public int IndexOf(T item)
    {
        int counter = 0;
        ListElement? element = heads[0].Next;
        while (element != null && element.Value!.CompareTo(item) != 0)
        {
            element = element.Next;
            counter++;
        }

        return element == null ? -1 : counter;
    }

    public void Insert(int index, T item) => throw new NotSupportedException();

    public bool Remove(T item)
    {
        bool value = false;
        RecursiveDelete(heads[^1], item, ref value);
        if (heads[^1].Next == null)
        {
            heads.RemoveAt(heads.Count - 1);
        }

        return value;
    }

    // Function for deleting an element
    private void RecursiveDelete(ListElement element, T item, ref bool value)
    {
        while (element.Next != null && element.Next.Value!.CompareTo(item) < 0)
        {
            element = element.Next;
        }

        if (element.Down != null)
        {
            RecursiveDelete(element.Down, item, ref value);
        }

        if (element.Next != null && element.Next.Value!.CompareTo(item) == 0)
        {
            element.Next = element.Next.Next;
            value = true;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        ListElement element = heads[0].Next!;
        int counter = 0;

        while (counter < index)
        {
            counter++;
            element = element.Next!;
        }

        Remove(element.Value!);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException();
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException();
        }

        ListElement element = heads[0];
        for (int counter = arrayIndex; counter < array.Length; counter++)
        {
            array[counter] = element.Value!;
            element = element.Next!;
        }
    }

    public void UpdateLevel()
    {
        if (heads.Count <= (int)Math.Floor(Math.Log2(Count)))
        {
            var newLevel = new ListElement();
            BuildLevel(newLevel);
            heads.Add(newLevel);
        }
    }

    public void Clear()
    {
        heads.Clear();
        Count = 0;
    }

    // Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

    // Implementation for the GetEnumerator method.
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();

    public SkipListEnum GetEnumerator()
    {
        return new SkipListEnum(this);
    }

    /// <summary>
    /// Class for implementing the IEnumerator<T> interface
    /// </summary>
    public class SkipListEnum : IEnumerator<T>
    {
        private readonly SkipList<T> list;
        private ListElement? head;

        public SkipListEnum(SkipList<T> inputList)
        {
            list = inputList;
            head = list.heads[0];
        }

        public bool MoveNext()
        {
            if (head != null && head.Next != null)
            {
                head = head.Next;
                return true;
            }
            else
            {
                head = null;
                return false;
            }
        }

        public void Reset() => head = list.heads[0];

        object IEnumerator.Current { get => Current; }

        public T Current
        {
            get
            {
                if (head != null)
                {
                    return head.Value!;
                }
                else
                {
                    return default!;
                }
            }
        }

        public void Dispose() { }
    }
}