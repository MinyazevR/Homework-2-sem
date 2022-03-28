using NUnit.Framework;
using List;

namespace ListTest;

public class Tests
{
    IUniqueList<int>? list;

    [SetUp]
    public void Setup()
    {
        list = new UniqueList<int>();
    }

    [Test]
    public void NumberOfElementsInEmptyListEqual0()
    {
        Assert.AreEqual(0, list?.ReturnSize());
    }

    [Test]
    public void ListShouldNotBeEmptyAfterPush()
    {
        list?.Add(1);
        Assert.AreEqual(1, list?.ReturnSize());
    }

    [Test]
    public void TryRemoveItemFromEmptyList()
    {
        Assert.Throws<RemoveNonExistenElementException>(() => list?.Remove(0));
    }

    [Test]
    public void RemoveNonExistenElementException()
    {
        list?.Add(1);
        list?.Add(2);
        list?.Add(0);
        list?.Add(-12);
        Assert.Throws<RemoveNonExistenElementException>(() => list?.Remove(4));
    }

    [Test]
    public void AddRepeatElement()
    {
        list?.Add(1);
        Assert.Throws<RepeatValueException>(() => list?.Add(1));
    }

    [Test]
    public void AddedElementMustContain()
    {
        list?.Add(12);
        Assert.AreEqual(true, list?.Contains(12));
    }

    [Test]
    public void NonExistenElementNotMustContain()
    {
        Assert.AreEqual(false, list?.Contains(10));
    }

    [Test]
    public void RemoveElementNotMustContain()
    {
        list?.Add(2);
        list?.Remove(0);
        Assert.AreEqual(false, list?.Contains(2));
    }

    [Test]
    public void ChangeNonExistenElement()
    {
        Assert.AreEqual(false, list?.ChangeElement(2, 12));
    }

    [Test]
    public void ContainsChangeElement()
    {
        list?.Add(125);
        list?.ChangeElement(0, 12);
        Assert.AreEqual(true, list?.Contains(12));
        Assert.AreEqual(false, list?.Contains(125));
    }
}