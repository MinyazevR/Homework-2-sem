namespace ListTest;

using NUnit.Framework;
using List;

public class Tests
{
    IUniqueList<int> list = new UniqueList<int>();

    [SetUp]
    public void Setup()
    {
        list = new UniqueList<int>();
    }

    [Test]
    public void ShouldExpectedZeroWhenListSizeEqualZero()
    {
        Assert.AreEqual(0, list.Size);
    }

    [Test]
    public void ShouldSizeIncrementedWhenSizeAfterAddNonExisintgElement()
    {
        list.Add(1);
        Assert.AreEqual(1, list.Size);
    }

    [Test]
    public void ShouldThrowsRemoveNonExistingElementExceptionWhenRemoveFromEmptyList()
    {
        Assert.Throws<RemoveNonExistingElementException>(() => list.Remove(0));
    }

    [Test]
    public void ShouldThrowsRemoveNonExistingElementExceptionWhenRemoveNonExistenElement()
    {
        list.Add(1);
        list.Add(2);
        list.Add(0);
        list.Add(-12);
        Assert.Throws<RemoveNonExistingElementException>(() => list.Remove(4));
    }

    [Test]
    public void ShouldThrowsRepeatValueExceptionWhenAddExistingElement()
    {
        list.Add(1);
        Assert.Throws<RepeatValueException>(() => list.Add(1));
    }

    [Test]
    public void ShouldExpectedTrueWhenContainsForExistingElement()
    {
        list.Add(12);
        Assert.AreEqual(true, list.Contains(12));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForExistingElement()
    {
        list.Add(2);
        Assert.AreEqual(false, list.Contains(10));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForRemovedElement()
    {
        list.Add(2);
        list.Remove(2);
        Assert.AreEqual(false, list.Contains(2));
    }

    [Test]
    public void ShouldExpectedFalseWhenChangeNonExistenElement()
    {
        Assert.AreEqual(false, list.ChangeElement(2, 12));
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsChangeReplacedElement()
    {
        list.Add(125);
        list.ChangeElement(0, 12);
        Assert.AreEqual(true, list.Contains(12));
        Assert.AreEqual(false, list.Contains(125));
    }
}