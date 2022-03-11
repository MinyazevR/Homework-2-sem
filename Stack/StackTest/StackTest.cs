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
        Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldNotEmptyAfterPush(IStack<int> stack)
    {
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnTopOfEmptyStack(IStack<int> stack)
    {
        var exception = Assert.Throws<StackException>(() => stack?.ReturnTopOfTheStack());
        Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAfterPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnTopOfTheStack(), 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnNumberOfElementForEmptyStack(IStack<int> stack)
    {
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 0);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnNumberOfElementAfterPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnNumberOfElementAfterPushAfterPop(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Pop();
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 0);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnNumberOfElementAfterPushPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Push(2);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 2);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ReturnTopOfTheStackAfterPushPushPop(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
        stack?.Push(2);
        stack?.Pop();
        Assert.AreEqual(stack?.ReturnNumberOfElements(), 1);
    }
}