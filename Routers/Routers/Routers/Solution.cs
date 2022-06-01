namespace Routers;

public class Solution
{
    static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Invalid input arguments");
            return -1;
        }

        IGraph graph = new Graph();
        graph.BuildGraph(args[0]);
        Graph? newGraph;

        try
        {
            newGraph = graph.BuildAcyclicGraph();
        }
        catch (DisconnectedGraph exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
            return -1;
        }

        if (newGraph == null)
        {
            return -1;
        }

        newGraph.PrintGraph(args[1]);
        return 0;
    }
}
