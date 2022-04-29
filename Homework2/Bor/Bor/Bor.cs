﻿namespace Bor;

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
        public Dictionary<char, Node> Nodes = new();

        // Node property - whether it is the end of a string
        public bool IsTerminal { get; set; }
    }

    // Bor root
    private readonly Node root = new();

    // Bor size
    public int Size { get; private set; }

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

        Node node = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (node != null && !node.Nodes.ContainsKey(element[i]))
            {
                node.Nodes.Add(element[i], new Node());
                Size++;
            }

            if (node != null && node.Nodes.ContainsKey(element[i]))
            {
                node = node.Nodes[element[i]];
            }
        }

        if (node != null)
        {
            node.IsTerminal = true;
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
            if (node.Nodes.TryGetValue(element[i], out node))
            {
                continue;
            }

            return false;
        }

        return node.IsTerminal;
    }

    /// <summary>
    /// Function for finding the number of strings starting with a prefix
    /// </summary>
    /// <returns> The number of strings starting with the prefix </returns>
    public int HowManyStartWithPrefix(string prefix)
    {
        Node? node = root;
        for (int i = 0; i < prefix.Length; i++)
        {
            if (node != null)
            {
                if (node.Nodes.TryGetValue(prefix[i], out node))
                {
                    continue;
                }
            }

            return 0;
        }

        if (node == null)
        {
            return 0;
        }

        return node.IsTerminal ? 1 + node.Nodes.Count : node.Nodes.Count;
    }

    // Function for clearing dictionaries
    static private void ClearDictionaryAndNode(Node node)
    {
        node.Nodes.Clear();
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
        Node node = root;
        Node? anotherNode = null;
        for (int i = 0; i < element.Length; i++)
        {
            if (node != null)
            {
                node = node.Nodes[element[i]];

                if (node.Nodes.Count == 0 && i == element.Length - 1)
                {
                    if (anotherNode != null)
                    {
                        ClearDictionaryAndNode(anotherNode);
                        Size -= i - index;
                        return true;
                    }
                    else
                    {
                        ClearDictionaryAndNode(root);
                        Size = 0;
                        return true;
                    }
                }

                if (node.Nodes.Count != 0 && i == element.Length - 1)
                {
                    node.IsTerminal = false;
                    return true;
                }
            }

            if (node != null && node.IsTerminal)
            {
                index = i;
                anotherNode = node;
            }

        }
        return true;
    }
}
