using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace TestStack;

[TestClass]
public class TestStackOnLists
{
    [TestMethod]
    public void TestPush()
    {
        StackOnLists<int> stackOnLists = new StackOnLists<int>();
        stackOnLists.Push(1);
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), 1);
        stackOnLists.Push(2);
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), 2);
        stackOnLists.Push(4);
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), 4);
        stackOnLists.Push(5);
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), 5);
    }

    [TestMethod]
    public void TestPop()
    {
        StackOnLists<string> stackOnLists = new StackOnLists<string>();
        stackOnLists.Push("first");
        stackOnLists.Push("second");
        stackOnLists.Push("hello");
        stackOnLists.Push("kek");
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), "hello");
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), "second");
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnTopOfTheStack(), "first");
    }

    [TestMethod]
    public void TestReturnNumberOfElements()
    {
        StackOnLists<string> stackOnLists = new StackOnLists<string>();
        stackOnLists.Push("first");
        stackOnLists.Push("second");
        stackOnLists.Push("hello");
        stackOnLists.Push("kek");
        Assert.AreEqual(stackOnLists.ReturnNumberOfElements(), 4);
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnNumberOfElements(), 3);
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnNumberOfElements(), 2);
        stackOnLists.Pop();
        Assert.AreEqual(stackOnLists.ReturnNumberOfElements(), 1);
    }
}
