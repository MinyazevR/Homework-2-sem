namespace QueueTest;

using NUnit.Framework;

public class QueueTest
{
    Queue.Queue<int> queque = new();

    [SetUp]
    public void Setup()
    {
        Queue.Queue<int> queque = new();
    }

    [Test]
    public void ShouldExpectedFalseWhenIsEmptyForNotEmptyQueue()
    {
        queque.Enqueue(12, 134);
        Assert.False(queque.IsEmpty());
    }


    [Test]
    public void ShouldExpectedPastValueWhenEnqueueForElementWithPriorityAlreadyExistInQueue()
    {
        queque.Enqueue(12, 200);
        queque.Enqueue(13, 200);
        Assert.AreEqual(12, queque.Dequeue());
    }

    [Test]
    public void ShouldExpectedNewFirstComingOutWhenEnqueueWithMaxPriority()
    {
        queque.Enqueue(12, 144);
        queque.Enqueue(13, 200);
        Assert.AreEqual(13, queque.Dequeue());
    }
}