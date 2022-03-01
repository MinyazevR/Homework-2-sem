using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace TestStack;

// A class for testing the stack on arrays
[TestClass]
public class TestStackOnArray
{

    // Testing a function for adding an element to the stack
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

    // Testing a function to remove an element from the stack
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

    // Testing a function to find the number of elements in the stack
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
