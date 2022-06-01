namespace MFPTest;

using NUnit.Framework;
using MFP;
using System.Collections.Generic;


public class Tests
{
    private static IEnumerable<TestCaseData> TestMapCaseData() => new TestCaseData[]
    {
        new TestCaseData(new List<int>(){ 2, 4, 6 }, MapFilterFold.Map<int, int>(new() { 1, 2, 3 }, x => x * 2)),
        new TestCaseData(new List<float>(){ 1/2, 1, 3/2 }, MapFilterFold.Map<int, float>(new() { 1, 2, 3 }, x => x / 2)),
        new TestCaseData(new List<string>(){ "1", "2", "3" }, MapFilterFold.Map<int, string>(new() { 1, 2, 3 }, x => x.ToString())),
        new TestCaseData(new List<string>(){}, MapFilterFold.Map<string, string>(new() {}, x => x)),
        new TestCaseData(new List<string> { "asdf", "bsdf", "sgsdf" }, MapFilterFold.Map<string, string>(new () { "a", "b", "sg" }, x => x + "sdf")),
        new TestCaseData(new List<int>(){ -1, 0, 1 }, MapFilterFold.Map<int, int>(new() { 1, 2, 3 }, x => x - 2)),
    };

    [TestCaseSource(nameof(TestMapCaseData))]
    public void TestMap<T>(List<T> expectedList, List<T> list)
    {
        Assert.AreEqual(expectedList, list);
    }

    private static IEnumerable<TestCaseData> TestFilterCaseData() => new TestCaseData[]
    {
        new TestCaseData(new List<int>(){ 2}, MapFilterFold.Filter<int>(new() { 1, 2, 3 }, x => x % 2 == 0)),
        new TestCaseData(new List<int>(){ -1, -12, -9 }, MapFilterFold.Filter<int>(new() { -1, 2, 3, -12, 123, -9 }, x => x < 0)),
        new TestCaseData(new List<string> { "pap", "pty" }, MapFilterFold.Filter<string>(new() { "pap", "b", "sg", "pty" }, x => x[0] == 'p')),
        new TestCaseData(new List<string>(){}, MapFilterFold.Filter<string>(new() {}, x => x == "aa")),
        new TestCaseData(new List<string>(){"hello", "world"}, MapFilterFold.Filter<string>(new() {"hello", "fefesa", "world", "eeee"}, x => x.Length == 5)),
    };

    [TestCaseSource(nameof(TestFilterCaseData))]
    public void TestFilter<T>(List<T> expectedList, List<T> list)
    {
        Assert.AreEqual(expectedList, list);
    }


    private static IEnumerable<TestCaseData> TestFoldCaseData() => new TestCaseData[]
    {
        new TestCaseData(6, MapFilterFold.Fold<int, int>(new() { 1, 2, 3 }, 1, (x, y) => x * y)),
        new TestCaseData( "lolkekab", MapFilterFold.Fold<string, string>(new List<string>() { "lol", "kek", "ab" }, "", (x, y) => x + y)),
        new TestCaseData("", MapFilterFold.Fold<string, string>(new List<string>() {}, "", (x, y) => x)),
    };

    [TestCaseSource(nameof(TestFoldCaseData))]
    public void TestFold<T>(T expectedValue, T value)
    {
        Assert.AreEqual(expectedValue, value);
    }
}