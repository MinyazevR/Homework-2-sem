using NUnit.Framework;
using Stack;
using System.Collections.Generic;
using System;

namespace StackTest;

/// <summary>
/// A class for testing the stack on arrays
/// </summary>
public class StackTest
{
    private static IEnumerable<TestCaseData> Stacks
    => new TestCaseData[]
    {
        new TestCaseData(new StackOnArray<int>()),
        new TestCaseData(new StackOnLists<int>()),
    };

    [TestCaseSource(nameof(Stacks))]
    public void RemoveElementFromEmptyStack(IStack<int> stack)
    {
        var exception = Assert.Throws<StackException>(() => stack?.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldNotEmptyAfterPush(IStack<int> stack)
    {
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckTopOfEmptyStack(IStack<int> stack)
    {
        var exception = Assert.Throws<StackException>(() => stack?.ReturnTopOfTheStack());
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckTopOfTheStackAfterPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnTopOfTheStack(), 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckNumberOfElementForEmptyStack(IStack<int> stack)
    {
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 0);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckNumberOfElementAfterPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckNumberOfElementsAfterPushAfterPop(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Pop();
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 0);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckNumberOfElementAfterPushPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Push(2);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 2);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckTopOfTheStackAfterPushPushPop(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Push(2);
        stack?.Pop();
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckTopOfTheStackAfterPushPush(IStack<int> stack)
    {
        stack?.Push(1);
        stack?.Push(2);
        Assert.AreEqual(stack?.ReturnTopOfTheStack(), 2);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CheckPopAfterPrint(IStack<int> stack)
    {
        stack?.Push(1);
        stack?.Push(2);
        stack?.PrintStack();
        Assert.AreEqual(stack?.ReturnTopOfTheStack(), 2);
    }
}