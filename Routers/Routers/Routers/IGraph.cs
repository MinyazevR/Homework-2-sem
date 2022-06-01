namespace Routers;

public interface IGraph
{
    /// <summary>
    /// Function for adding a node
    /// </summary>
    /// <param name="index">Node value</param>
    /// <returns>Was there a value in the graph</returns>
    public bool AddNode(int index);

    /// <summary>
    /// Function for creating an edge between vertices
    /// </summary>
    /// <param name="valueFirstNode">Value of the first node</param>
    /// <param name="valueSecondNode">Value of the second node</param>
    /// <param name="length">Edge length</param>
    /// <returns>Was there an edge in the graph</returns>
    public bool SetLength(int valueFirstNode, int valueSecondNode, int length);

    /// <summary>
    /// Function for constructing a new graph without cycles
    /// </summary>
    /// <returns>Acyclic graph, with maximum sum of edges</returns>
    public Graph BuildAcyclicGraph();

    /// <summary>
    /// Function for graph construction 
    /// </summary>
    /// <param name="pathToFile">The path to the file with the table</param>
    public void BuildGraph(string pathToFile);

    /// <summary>
    /// Function for graph printing
    /// </summary>
    /// <param name="pathToFile">File path</param>
    public void PrintGraph(string pathToFile);

    /// <summary>
    /// Function for checking the connectivity of a graph
    /// </summary>
    /// <returns>Is the graph connected</returns>
    public bool IsTheGraphConnected();
}