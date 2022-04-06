namespace GraphTest;

using NUnit.Framework;
using Routers;

public class Tests
{
    IGraph? graph = null;
    [SetUp]
    public void Setup()
    {
        graph = new Graph(); 
    }

    [Test]
    public void DisconnectedGraph()
    {
        graph?.BuildGraph("..//..//..//InputTest.txt");
        Assert.Throws<DisconnectedGraph>(() => graph?.BuildNewGraph());
    }
}