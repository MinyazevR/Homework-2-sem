namespace GraphTest;

using NUnit.Framework;
using Routers;

public class Tests
{
    IGraph graph = new Graph();

    [SetUp]
    public void Setup()
    {
        graph = new Graph(); 
    }

    [Test]
    public void ShouldExpectedFalseWhenIsTheGraphConnectedForDisconnectGraph()
    {
        graph.AddNode(2);
        graph.AddNode(4);
        graph.AddNode(6);
        graph.AddNode(7);
        graph.AddNode(1);
        graph.AddNode(5);
        graph.AddNode(9);
        graph.AddNode(8);

        graph.SetLength(6, 9, 12);
        graph.SetLength(2, 4, 3);
        graph.SetLength(2, 6, 4);
        graph.SetLength(2, 7, 8);
        graph.SetLength(2, 5, 2);
        graph.SetLength(7, 8, 13);

        Assert.False(graph.IsTheGraphConnected());
    }

    [Test]
    public void ShouldExpectedTrueWhenIsTheGraphConnectedForGraphConsisting1Node()
    {
        graph.AddNode(2);
        Assert.True(graph.IsTheGraphConnected());
    }

    [Test]
    public void ShouldExpectedTrueWhenIsTheGraphConnectedForEmptyGraph()
    {
        Assert.True(graph.IsTheGraphConnected());
    }

    [Test]
    public void ShouldThrowsDisconnectedGraphWhenBuildAcyclicGraphForDisconnectGraph()
    {
        graph.AddNode(2);
        graph.AddNode(4);
        graph.AddNode(6);
        graph.AddNode(7);
        graph.AddNode(1);
        graph.AddNode(5);
        graph.AddNode(9);
        graph.AddNode(8);

        graph.SetLength(2, 4, 3);
        graph.SetLength(2, 6, 4);
        graph.SetLength(2, 7, 8);
        graph.SetLength(2, 5, 2);
        graph.SetLength(7, 8, 13);

        Assert.Throws<DisconnectedGraph>(() => graph.BuildAcyclicGraph());
    }

    [Test]
    public void ShouldExpectedTrueWhenIsTheGraphConnectedForConnectedGraph()
    {
        graph.AddNode(2);
        graph.AddNode(4);
        graph.AddNode(6);
        graph.AddNode(7);
        graph.AddNode(1);
        graph.AddNode(5);
        graph.AddNode(9);
        graph.AddNode(8);

        graph.SetLength(1, 6, 12);
        graph.SetLength(6, 9, 12);
        graph.SetLength(2, 4, 3);
        graph.SetLength(2, 6, 4);
        graph.SetLength(2, 7, 8);
        graph.SetLength(2, 5, 2);
        graph.SetLength(7, 8, 13);

        Assert.True(graph.IsTheGraphConnected());
    }

    [Test]
    public void ShouldExpectedFalseWhenAddExistingNode()
    {
        graph.AddNode(2);
        Assert.False(graph.AddNode(2));
    }

    [Test]
    public void ShouldExpectedFalseWhenSetLengthForNonExistingNode()
    {
        Assert.False(graph.SetLength(2, 6, 4));
    }

    [Test]
    public void DisconnectedGraph()
    {
        graph.BuildGraph("..//..//..//InputTest.txt");
        Assert.Throws<DisconnectedGraph>(() => graph.BuildAcyclicGraph());
    }
}