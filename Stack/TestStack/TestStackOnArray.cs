using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace TestStack;

[TestClass]
public class TestStackOnArray
{ 
    [TestMethod]
    public void TestPush()
    {
        StackOnArray<int> stackOnArray = new StackOnArray<int>();
        stackOnArray.Push(1);
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), 1);
        stackOnArray.Push(2);
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), 2);
        stackOnArray.Push(4);
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), 4);
        stackOnArray.Push(5);
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), 5);
    }

    [TestMethod]
    public void TestPop()
    {
        StackOnArray<string> stackOnArray = new StackOnArray<string>();
        stackOnArray.Push("first");
        stackOnArray.Push("second");
        stackOnArray.Push("hello");
        stackOnArray.Push("kek");
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), "hello");
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), "second");
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnTopOfTheStack(), "first");
    }

    [TestMethod]
    public void TestReturnNumberOfElements()
    {
        StackOnArray<string> stackOnArray = new StackOnArray<string>();
        stackOnArray.Push("first");
        stackOnArray.Push("second");
        stackOnArray.Push("hello");
        stackOnArray.Push("kek");
        Assert.AreEqual(stackOnArray.ReturnNumberOfElements(), 4);
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnNumberOfElements(), 3);
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnNumberOfElements(), 2);
        stackOnArray.Pop();
        Assert.AreEqual(stackOnArray.ReturnNumberOfElements(), 1);
    }
}
