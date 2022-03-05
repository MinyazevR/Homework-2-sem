using System;

namespace String;

/// <summary>
/// A class representing the bor data structure
/// The bor can store Latin alphabet characters, numbers
/// </summary>
public class Bor
{
    /// <summary>
    /// // A class representing the bor data structure
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Array of vertices to move from one vertex to another
        /// The bor can store Latin alphabet characters, numbers
        /// </summary>
        public Node?[] next = new Node['z'];

        // A field for storing information about whether a character is the end of a string
        public bool isTerminal { get; set; }

        // A field for storing information about the number of strings containing a certain prefix
        public int numberOfLinesContainingThePrefix { get; set; }
    }

    private Node root = new Node();

    // Bor size
    private int size;

    /// <summary>
    /// Function for adding a string
    /// </summary>
    /// <param name="element"> Element to add </param>
    /// <returns> Was there an element string before calling Add </returns>
    public bool Add(string element)
    {
        Node? node = root;
        int counter = 0;
        for(int i = 0; i < element.Length; i++)
        {
            if(element[i] > 'z')
            {
                throw new Exception("The bor can store Latin alphabet characters, numbers"); ;
            }
            if (node != null && node.next[element[i]] == null)
            {
                node.next[element[i]] = new Node();
                size++;
            }
            else
            {
                counter++;
            }
            if (node != null)
            {
                node = node.next[element[i]];
                if(node != null)
                {
                    node.numberOfLinesContainingThePrefix++;
                }
            }
        }
        if (counter == element.Length && node != null && node.isTerminal)
        {
            Node? newNode = root;
            for (int i = 0; i < element.Length; i++)
            {
                newNode = newNode?.next[element[i]];
                if(newNode != null)
                {
                    newNode.numberOfLinesContainingThePrefix--;
                }
            }
            return false;
        }
        if (node != null)
        {
            node.isTerminal = true;
        }
        return true;
    }

    /// <summary>
    /// Is the string contained in the Bor
    /// </summary>
    /// <param name="element"> Element to search </param>
    /// <returns> True if there is such a string. False if there is no such string </returns>
    public bool Contains(string element)
    {
        Node? node = root;
        for (int i = 0; i < element.Length; i++)
        {
            node = node.next[element[i]];
            if (node == null)
            {
                return false;
            }
        }
        return node.isTerminal;
    }

    /// <summary>
    /// Function for finding the number of strings starting with a prefix
    /// </summary>Количество строк содеражащих префикс
    /// <returns> The number of strings starting with the prefix </returns>
    public int HowManyStartWithPrefix(string prefix)
    {
        Node? node = root;
        for (int i = 0; i < prefix.Length;i++)
        {
            if (node?.next[prefix[i]] != null)
            {
                node = node.next[prefix[i]];
            }
            else
            {
                return 0;
            }
        }
        return node == null ? 0 : node.numberOfLinesContainingThePrefix;
    }

    /// <summary>
    /// Function for deleting string from a Bor
    /// </summary>
    /// <param name="element"> Element to delete </param>
    /// <returns> as there an element string before calling Remove </returns>
    public bool Remove(string element)
    {
        if(!this.Contains(element))
        {
            return false;
        }
        Node? node = root;
        Node? nodeWithMaxPrefix = root;
        for (int i = 0; i < element.Length; i++)
        {
            node = node?.next[element[i]];
            if(node != null)
            {
                node.numberOfLinesContainingThePrefix--;
            }
            if (i == element.Length - 1)
            {
                nodeWithMaxPrefix.isTerminal = false;
            }
        }
        node = root;
        for (int i = 0; i < element.Length; i++)
        {
            nodeWithMaxPrefix = node;
            node = node?.next[element[i]];
            if (nodeWithMaxPrefix?.next[element[i]]?.numberOfLinesContainingThePrefix == 0)
            {
                nodeWithMaxPrefix.next[element[i]] = null;
            }

        }
        return true;
    }

    /// <summary>
    /// Function for returning the number of elements
    /// </summary>
    /// <returns> Number of elements contained in the bor </returns>
    public int Size()
    {
        return this.size;
    }

    static void Main(string[] args)
    {
        return;
    }
}
