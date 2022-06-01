namespace Routers;

using System;
using System.Collections.Generic;

/// <summary>
/// Class representing a graph
/// </summary>
public class Graph : IGraph
{
    /// <summary>
    /// Class for storing graph vertices
    /// </summary>
    private class Node
    {
        // Useless dictionary needed to output a table to a file by condition
        public Dictionary<int, int> newDictionary = new();
    }

    public Graph(){ }

    public Graph (int x)
    {
        AddNode(x);
    }

    /// List for storing vertices
    private readonly List<Node> nodes = new();

    /// List for storing vertex values
    /// nodes[0] corresponds to nodeValue[0]
    private readonly List<int> nodeValue = new();

    /// Dictionary of Adjacency
    /// The key is a pair of vertices, the value is the length of the edge between them
    private Dictionary<(int, int), int> adjacencyDictionary = new();

    /// <summary>
    /// Function for adding a node
    /// </summary>
    /// <param name="index">Node value</param>
    /// <returns>Was there a value in the graph</returns>
    public bool AddNode(int index)
    {
        if (!nodeValue.Contains(index))
        {
            nodes.Add(new());
            nodeValue.Add(index);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Function for creating an edge between vertices
    /// </summary>
    /// <param name="valueFirstNode">Value of the first node</param>
    /// <param name="valueSecondNode">Value of the second node</param>
    /// <param name="length">Edge length</param>
    /// <returns>Was there an edge in the graph</returns>
    public bool SetLength(int valueFirstNode, int valueSecondNode, int length)
    {
        if (!nodeValue.Contains(valueFirstNode) || !nodeValue.Contains(valueSecondNode) || valueSecondNode == valueFirstNode)
        {
            return false;
        }

        if (adjacencyDictionary.ContainsKey((valueFirstNode, valueSecondNode)))
        {
            adjacencyDictionary.Remove((valueFirstNode, valueSecondNode));
        }

        adjacencyDictionary.Add((valueFirstNode, valueSecondNode), length);
        return true;
    }

    /// <summary>
    /// Function for constructing a new graph without cycles
    /// </summary>
    /// <returns>Acyclic graph, with maximum sum of edges</returns>
    public Graph BuildAcyclicGraph()
    {
        if (!IsTheGraphConnected())
        {
            throw new DisconnectedGraph();
        }

        // List of subgraphs, each of which initially contains a vertex from the original graph
        List<Graph> subgraphs = new();

        // The keys are nodes, the value is the index of the graph with the list in which the node is located
        Dictionary<int, int> graphInWhichTheNodeIsLocated = new();

        for (int i = 0; i < nodeValue.Count; i++)
        {
            subgraphs.Add(new(nodeValue[i]));
            graphInWhichTheNodeIsLocated.Add(nodeValue[i], i);
        }

        ///Dictionary of the adjacency of the original graph, but with values sorted in descending order
        adjacencyDictionary = adjacencyDictionary.OrderBy(x => x.Value, new Comparator()).ToDictionary(x => x.Key, x => x.Value);

        /// We will go by the values in the adjacency dictionary. 
        /// If two vertices are in different graphs, then we combine 
        /// them into one graph by combining all existing vertices and adding a new edge. 
        /// If two vertices already lie in the same graph, 
        /// then adding an edge with the same vertices will result in a cycle, so in this case we do nothing.
        /// Eventually there will remain one acyclic graph with the maximum sum of edges
        while (subgraphs.Count != 1)
        {
            // For each pair of vertices from the adjacency dictionary
            foreach ((int, int) edgeVertices in adjacencyDictionary.Keys)
            {
                var (firstNode, secondNode) = edgeVertices;
                var length = adjacencyDictionary[edgeVertices];
                if (graphInWhichTheNodeIsLocated[firstNode] == graphInWhichTheNodeIsLocated[secondNode])
                {
                    continue;
                }

                else
                {
                    CombineTwoGraphs(firstNode, secondNode, length, subgraphs, graphInWhichTheNodeIsLocated);
                }
            }
        }

        return subgraphs[0];
    }

    /// <summary>
    /// Function for combining two graphs
    /// </summary>
    /// <param name="firstNode">Value of the first node</param>
    /// <param name="secondNode">Value of the second node</param>
    /// <param name="length">Edge length</param>
    /// <param name="subgraphs">List of graphs</param>
    private static void CombineTwoGraphs(int firstNode, int secondNode, int length, List<Graph> subgraphs, Dictionary<int, int> dictionary)
    {
        Graph firstGraph = subgraphs[dictionary[firstNode]];
        Graph secondGraph = subgraphs[dictionary[secondNode]];

        for (int i = 0; i < firstGraph.nodeValue.Count; i++)
        {
            secondGraph.AddNode(firstGraph.nodeValue[i]);
        }

        secondGraph.adjacencyDictionary =
        firstGraph.adjacencyDictionary.Concat(secondGraph.adjacencyDictionary).ToDictionary(x => x.Key, x => x.Value);
        secondGraph.adjacencyDictionary.Add((firstNode, secondNode), length);

        firstGraph.nodes.Clear();
        firstGraph.nodeValue.Clear();
        firstGraph.adjacencyDictionary.Clear();
        subgraphs.Remove(firstGraph);
    }

    /// <summary>
    /// useless function designed to create a new dictionary for easy output to a file
    /// </summary>
    private void ConvertToAnotherDictionary()
    {
        foreach ((int, int) h in adjacencyDictionary.Keys)
        {
            var (first, second) = h;
            nodes[nodeValue.IndexOf(first)].newDictionary.Add(second, adjacencyDictionary[h]);
        }
    }

    private List<int> NumberOfConnectedGraphElements(int nodeIndex, List<int> isTerminal)
    {
        isTerminal.Add(nodeIndex);
        var array = new List<int>();
        foreach ((int, int) h in adjacencyDictionary.Keys)
        {
            var (first, second) = h;
            if (first == nodeIndex)
            {
                array.Add(second);
            }
            else if (second == nodeIndex)
            {
                array.Add(first);
            }
        }

        foreach (int item in array)
        {
            if (!isTerminal.Contains(item))
            {
                NumberOfConnectedGraphElements(item, isTerminal);
            }
        }

        return isTerminal;
    }

    /// <summary>
    /// Function for checking the connectivity of a graph
    /// </summary>
    /// <returns>Is the graph connected</returns>
    public bool IsTheGraphConnected()
    => nodeValue.Count == 0 || NumberOfConnectedGraphElements(nodeValue[0], new()).Count == nodes.Count;

    /// <summary>
    /// Function for graph constructionПуть 
    /// </summary>
    /// <param name="pathToFile">The path to the file with the table</param>
    public void BuildGraph(string pathToFile)
    {
        var stringToConvert = File.ReadAllLines(pathToFile);
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            var newStringArray = stringToConvert[i].Split(' ');
            if (Int32.TryParse(newStringArray[0], out int firstNumber))
            {
                AddNode(firstNumber);
            }

            int secondNumber = 0;
            for (int j = 1; j < newStringArray.Length; j++)
            {
                if (newStringArray[j] == ":")
                {
                    continue;
                }

                if (Int32.TryParse(newStringArray[j], out int number))
                {
                    AddNode(number);
                    secondNumber = number;
                }

                else
                {
                    int k = 0;
                    string newNumber = "";
                    while (newStringArray[j][k] != ')')
                    {
                        if (newStringArray[j][k] == '(' || newStringArray[j][k] == ',')
                        {
                            k++;
                            continue;
                        }

                        newNumber += newStringArray[j][k];
                        k++;
                    }

                    if (Int32.TryParse(newNumber, out int length))
                    {
                        SetLength(firstNumber, secondNumber, length);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Function for graph printing
    /// </summary>
    /// <param name="pathToFile">File path</param>
    public void PrintGraph(string pathToFile)
    {
        ConvertToAnotherDictionary();
        using StreamWriter writer = new(pathToFile);
        {
            for (int i = 0; i < nodeValue.Count; i++)
            {
                if (nodes[i].newDictionary.Keys.Count != 0)
                {
                    writer.Write($"{nodeValue[i]} : ");
                }

                else
                {
                    continue;
                }

                foreach (int key in nodes[i].newDictionary.Keys)
                {
                    writer.Write($"{key} ({nodes[i].newDictionary[key]}), ");
                }

                writer.WriteLine();
            }
        }
    }
}
