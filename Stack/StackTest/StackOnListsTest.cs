using NUnit.Framework;

using Stack;
using System;

namespace StackTest;

public class StackOnListsTest
{
    StackOnLists<int>? stackOnLists;

    [SetUp]
    public void Setup()
    {
        stackOnLists = new StackOnLists<int>();
    }

    [Test]
    public void RemoveElementFromEmptyStack()
    {
        var exception = Assert.Throws<NullReferenceException>(() => stackOnLists?.Pop());
        Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
    }

    [Test]
    public void ReturnTopOfEmptyStack()
    {
        var exception = Assert.Throws<NullReferenceException>(() => stackOnLists?.ReturnTopOfTheStack());
        Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
    }

    [Test]
    public void ReturnTopOfStackAfterPush()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnTopOfTheStack(), 1);
    }

    [Test]
    public void PushAfterPush()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnTopOfTheStack(), 1);
    }

    [Test]
    public void ReturnNumberOfElementForEmptyStack()
    {
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 0);
    }

    [Test]
    public void ReturnNumberOfElementAfterPush()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 1);
    }

    [Test]
    public void ReturnNumberOfElementAfterPushAfterPop()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 1);
        stackOnLists?.Pop();
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 0);
    }

    [Test]
    public void ReturnNumberOfElementAfterPushPush()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 1);
        stackOnLists?.Push(2);
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 2);
    }

    [Test]
    public void ReturnTopOfTheStackAfterPushPushPop()
    {
        stackOnLists?.Push(1);
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 1);
        stackOnLists?.Push(2);
        stackOnLists?.Pop();
        Assert.AreEqual(stackOnLists?.ReturnNumberOfElements(), 1);
    }
}
