namespace Trie;

/// <summary>
/// A class representing the bor data structure
/// </summary>
public class Trie
{
    /// <summary>
    /// // A class representing the bor data structure
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Dictionary for storing characters for each node
        /// </summary>
        public Dictionary<byte, Node> Nodes = new();

        /// <summary>
        /// Code for each node
        /// </summary>
        public int Code { get; set;}
    }

    /// <summary>
    /// Bor root
    /// </summary>
    private readonly Node root = new();

    /// <summary>
    /// Bor size
    /// </summary>
    public int Size { get; private set; }

    private Node currentNode;

    /// <summary>
    /// Function for getting the code of the current element
    /// </summary>
    /// <returns></returns>
    public int GetCode() => currentNode.Code;

    /// <summary>
    /// Trie constructor
    /// </summary>
    public Trie()
    {
        root.Code = -1;

        // Initialize the bor with numbers from 0 to 256
        for (int i = 0; i < 256; i++)
        {
            Node node = new();
            root.Nodes.Add((byte)i, node);
            node.Code = Size;
            Size++;
        }

        // The current node is the root
        currentNode = root;
    }

    /// <summary>
    /// Function to add a byte
    /// </summary>
    /// <param name="byteToAdd"> Byte to add </param>
    public void Add(byte byteToAdd)
    {
        Node node = new();
        currentNode?.Nodes.Add(byteToAdd, node);
        currentNode = root;
        node.Code = Size;
        Size++;
    }

    /// <summary>
    /// Is the byte contained in Current Node
    /// </summary>
    /// <param name="element"> Element to search </param>
    /// <returns> True if there is such a byte. False if there is no such byte </returns>
    public bool Contains(byte byteToSearch) => currentNode.Nodes.ContainsKey(byteToSearch);

    /// <summary>
    /// Function for moving to another node
    /// </summary>
    /// <param name="byteT">the byte to be moved to</param>
    public void MoveIntoDesiredNode(byte byteToBeMovedTo) => currentNode = currentNode.Nodes[byteToBeMovedTo];

    /// <summary>
    /// Function for moving to root
    /// </summary>
    public void MovedToRoot() => currentNode = root;
}

