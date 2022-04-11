namespace TestStack;

using NUnit.Framework;
using Stack;
using System.Collections.Generic;

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
    public void ShouldThrowsStackExceptionWhenRemoveFromEmptyStack(IStack<int> stack)
    {
        Assert.Throws<StackIsEmptyException>(() => stack?.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldStackNotEmptyAfterPush(IStack<int> stack)
    {
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldThrowsStackExceptionWhenTopOfTheStackFromEmptyStack(IStack<int> stack)
    {
        Assert.Throws<StackIsEmptyException>(() => stack?.TopOfTheStack());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldTopOfTheStackEqual1WhenPush1(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(1, stack?.TopOfTheStack());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldNumberOFElementsEqualZeroWhenEmptyStack(IStack<int> stack)
    {
        Assert.AreEqual(0, stack?.NumberOfElements());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldNumberOfElementsEqual1WhenPushInEmptyStack(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(1, stack?.NumberOfElements());
    }

    [TestCaseSource(nameof(Stacks))]
    public void ShouldNumberOfElementsNotChangesWhenRemoveAfterPush(IStack<int> stack)
    {
        stack?.Push(1);
        Assert.AreEqual(1, stack?.NumberOfElements());
        stack?.Pop();
        Assert.AreEqual(0, stack?.NumberOfElements());
    }


    [TestCaseSource(nameof(Stacks))]
    public void ShouldTopOfTheStackNotChangesWhenPrintStack(IStack<int> stack)
    {
        stack?.Push(1);
        stack?.Push(2);
        stack?.PrintStack();
        Assert.AreEqual(2, stack?.TopOfTheStack());
    }
}
