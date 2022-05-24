namespace SkipListTest;

using NUnit.Framework;
using SkipList;
using System;
using System.Collections.Generic;

public class Tests
{ 
    IList<int> list = new SkipList<int>();

    [SetUp]
    public void Setup()
    {
        list = new SkipList<int>();
    }

    private static IEnumerable<TestCaseData> TestRemoveCaseData() => new TestCaseData[]
    {
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123}, 2, (IList<int> list) => list.Remove(2), false),
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123}, 12, (IList<int> list) => list.Remove(12), false),
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123, 2}, 2,(IList<int> list) => list.Remove(2), true),
    };

    private static IEnumerable<TestCaseData> TestRemoveFunctionValueCaseData() => new TestCaseData[]
    {
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123}, (IList<int> list) => list.Remove(2), true),
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123}, (IList<int> list) => list.Remove(12), true),
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123, 2}, (IList<int> list) => list.Remove(16), false),
        new TestCaseData(new SkipList<int>(){}, (IList<int> list) => list.Remove(0), false),
    };

    private static IEnumerable<TestCaseData> TestIndexOfCaseData() => new TestCaseData[]
    {
        new TestCaseData(4, new SkipList<int>(){2, 1, 14, 12, -123}.IndexOf(14)), 
        new TestCaseData(1, new SkipList<int>(){2, 1, 14, 12, -123}.IndexOf(1)),
        new TestCaseData(-1, new SkipList<int>(){2, 1, 14, 12, -123}.IndexOf(-50)),
        new TestCaseData(-1, new SkipList<int>(){}.IndexOf(0)),
    };

    private static IEnumerable<TestCaseData> TestRemoveAtFunctionValueCaseData() => new TestCaseData[]
    {
        new TestCaseData(new SkipList<int>(){2, 1, 18, 12, -123}, 2, (IList<int> list) => list.RemoveAt(2), true),
        new TestCaseData(new SkipList<int>(){5, 1, 18, 12, -123, 5}, 5, (IList<int> list) => list.RemoveAt(2), true),
    };


    [Test]
    public void ShouldForeachWork()
    {
        list.Add(12);
        list.Add(0);
        list.Add(-1);
        list.Add(123);
        list.Add(5);
        list.Add(124);
        list.Add(70);
        list.Add(85);
        list.Add(19);
        list.Add(42);
        list.Add(53);
        list.Add(68);
        list.Add(14);
        list.Add(80);

        int counter = 0;
        foreach (int item in list)
        {
            Assert.AreEqual(list[counter], item);
            counter++;
        }
    }

    [Test]
    public void ShouldExpectedCountEqualZeroWhenDoNothing()
    {
        Assert.AreEqual(0, list.Count);
    }

    [Test]
    public void ShouldPropertyWorkCorrectly()
    {
        list.Add(12);
        list.Add(0);
        list.Add(-1);
        list.Add(144);
        Assert.AreEqual(-1, list[0]);
        Assert.AreEqual(0, list[1]);
        Assert.AreEqual(12, list[2]);
        Assert.AreEqual(144, list[3]);
    }

    [Test]
    public void ShouldExpected0WhenCountAfterListClear()
    {
        list.Add(12);
        list.Add(0);
        list.Add(-1);
        list.Add(144);
        list.Clear();
        Assert.AreEqual(0, list.Count);
    }

    [Test]
    public void ShouldExpectedFalseWhenContainsForNonExistingElement()
    {
        Assert.False(list.Contains(12));
    }

    [TestCaseSource(nameof(TestIndexOfCaseData))]
    public void ShouldExpectedMinus1OrRealIndexWhenContainsForNonExistingElement(int expectedValue, int value)
    {
        Assert.AreEqual(expectedValue, value);
    }

    [TestCaseSource(nameof(TestRemoveCaseData))]
    public void ShouldExpectedTrueOrFalseWhenContainsAfterRemove(SkipList<int> list, int expectedValue, Func<IList<int>, bool> func, bool answer)
    {
        func(list);
        Assert.AreEqual(answer, list.Contains(expectedValue));
    }

    [TestCaseSource(nameof(TestRemoveFunctionValueCaseData))]
    public void ShouldExpectedTrueOrFalseWhenRemove(SkipList<int> list, Func<IList<int>, bool> func, bool answer)
    {
        Assert.AreEqual(answer, func(list));
    }


    [TestCaseSource(nameof(TestRemoveAtFunctionValueCaseData))]
    public void ShouldExpectedTrueOrFalseWhenContainsAfterRemoveAt(SkipList<int> list, int expectedValue, Action<IList<int>> func, bool answer)
    {
        func(list);
        Assert.AreEqual(answer, list.Contains(expectedValue));
    }

    public void ShouldExpectedNextElementWhenRemoveElement()
    {
        list.Add(12);
        list.Add(1);
        list.Add(18);
        list.Add(-123);
        list.Remove(12);
        Assert.AreEqual(18,list[2]);
    }

    public void ShouldArgumentOutOfRangeExceptionWhenIndexIsNotValidIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(13));
    }
}
