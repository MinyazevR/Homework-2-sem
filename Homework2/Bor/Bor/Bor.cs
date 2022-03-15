using System;

namespace BorSpace;

/// <summary>
/// A class representing the bor data structure
/// </summary>
public class Bor
{
    /// <summary>
    /// // A class representing the bor data structure
    /// </summary>
    private class Node
    {
        // Dictionary for storing characters for each node
        public Dictionary<char, Node> dictionary = new Dictionary<char, Node>();

        // A field for storing information about whether a character is the end of a string
        public bool isTerminal { get; set; }
    }

    // Bor root
    private Node root = new();

    // Bor size
    private int size;

    /// <summary>
    /// Function for adding a string
    /// </summary>
    /// <param name="element"> Element to add </param>
    /// <returns> Was there an element string before calling Add </returns>
    public bool Add(string element)
    {
        if (Contains(element))
        {
            return false;
        }
        Node? node = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (node != null && !node.dictionary.ContainsKey(element[i]))
            {
                node.dictionary.Add(element[i], new Node());
                size++;
            }
            if (node != null && node.dictionary.ContainsKey(element[i]))
            {
                node.dictionary.TryGetValue(element[i], out node);
            }
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
            node.dictionary.TryGetValue(element[i], out node);
            if (node == null)
            {
                return false;
            }
        }
        return node.isTerminal;
    }

    /// <summary>
    /// Function for finding the number of strings starting with a prefix
    /// </summary>
    /// <returns> The number of strings starting with the prefix </returns>
    public int HowManyStartWithPrefix(string prefix)
    {
        Node? node = root;
        for (int i = 0; i < prefix.Length;i++)
        {
            if (node!= null)
            {
                node.dictionary.TryGetValue(prefix[i], out node);
            }
            else
            {
                return 0;
            }
        }
        if (node == null)
        {
            return 0;
        }
        return node.isTerminal ? 1 + node.dictionary.Count() : node.dictionary.Count();
    }

    // Function for clearing dictionaries
    static void ClearDictionaryAndNode(string element, int index, Node? node)
    {
        if (index + 1 < element.Length - 1 && node != null)
        {
            node.dictionary.TryGetValue(element[index + 1], out node);
            ClearDictionaryAndNode(element, index + 1, node);
        }
        if (node != null)
        {
            node.dictionary.Clear();
            node = null;
        }
    }

    /// <summary>
    /// Function for deleting string from a Bor
    /// </summary>
    /// <param name="element"> Element to delete </param>
    /// <returns> as there an element string before calling Remove </returns>
    public bool Remove(string element)
    {
        if (!Contains(element))
        {
            return false;
        }
        int index = 0;
        Node? node = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (node != null)
            {
                node.dictionary.TryGetValue(element[i], out node);
            }
            string subString = element.Substring(0, i + 1);
            if (HowManyStartWithPrefix(subString) < 2)
            {
                index = i;
                break;
            }
        }
        ClearDictionaryAndNode(element, index, node);
        return true;
    }

    /// <summary>
    /// Function for returning the number of elements
    /// </summary>
    /// <returns> Number of elements contained in the bor </returns>
    public int Size()
    {
        return size;
    }

    static void Main(string[] args)
    {
    }
}
