namespace BubbleSortTests;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Sort;

public class BubbleSortTests
{

    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<TestCaseData> IntComparatorTestData() => new TestCaseData[]
    {
        new TestCaseData(new List<int>(){2, 1, 18, 12, -123}, new IntComparator(), new List<int>(){-123, 1, 2, 12, 18}),
        new TestCaseData(new List<int>(){}, new IntComparator(), new List<int>(){}),
        new TestCaseData(new List<int>(){2}, new IntComparator(), new List<int>(){2}),
        new TestCaseData(new List<int>(){12, 12, 12, 12, 12, 12, 12, 12, 12, 12}, new IntComparator(), new List<int>(){12, 12, 12, 12, 12, 12, 12, 12, 12, 12}),
        new TestCaseData(new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new IntComparator(), new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0}),


        new TestCaseData(new List<int>(){2, 1, 18, 12, -123}, new DescIntComparator(), new List<int>(){18, 12, 2, 1, -123}),
        new TestCaseData(new List<int>(){}, new DescIntComparator(), new List<int>(){}),
        new TestCaseData(new List<int>(){2}, new DescIntComparator(), new List<int>(){2}),
        new TestCaseData(new List<int>(){12, 12, 12, 12, 12, 12, 12, 12, 12, 12}, new DescIntComparator(), new List<int>(){12, 12, 12, 12, 12, 12, 12, 12, 12, 12}),
        new TestCaseData(new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new DescIntComparator(), new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0}),
    };

    [TestCaseSource(nameof(IntComparatorTestData))]
    public void ShouldExpectedSortedListForIntComparator(List<int> list, IComparer<int> comparator, List<int> expectedList)
    {
        var newList = Sort.BubbleSort<int>(list, comparator);
        for (int i = 0; i < newList.Count; i++)
        {
            if (newList[i] != expectedList[i])
            {
                Assert.Fail();
            }
        }
    }

    private static IEnumerable<TestCaseData> StringComparatorTestData() => new TestCaseData[]
    {
        new TestCaseData(new List<string>(){"caba", "kek", "aba"}, new StringComparator(), new List<string>(){"aba", "caba", "kek" }),
        new TestCaseData(new List<string>(){"a"}, new StringComparator(), new List<string>(){"a"}),
        new TestCaseData(new List<string>(){"v", "v", "v", "v", "v"}, new StringComparator(), new List<string>(){"v", "v", "v", "v", "v"}),
        new TestCaseData(new List<string>(){"", "", "", ""}, new StringComparator(), new List<string>(){"", "", "", ""}),
    };

    [TestCaseSource(nameof(StringComparatorTestData))]
    public void ShouldExpectedSortedListForStringComparator(List<string> list, IComparer<string> comparator, List<string> expectedList)
    {
        var newList = Sort.BubbleSort<string>(list, comparator);
        for (int i = 0; i < newList.Count; i++)
        {
            if (newList[i] != expectedList[i])
            {
                Assert.Fail();
            }
        }
    }

}
