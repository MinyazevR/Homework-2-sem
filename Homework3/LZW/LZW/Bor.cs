namespace Bor;

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
        public Dictionary<byte, Node> Nodes = new();

        // Code for each node
        public int Code { get; set;}
    }

    // Bor root
    private readonly Node root = new();

    // Bor size
    public int Size { get; private set; }

    private Node currentNode;

    public int GetCode()
    {
        return currentNode.Code;
    }

    public Bor()
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
    /// <param name="byteToAdd"> byte to add </param>
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

