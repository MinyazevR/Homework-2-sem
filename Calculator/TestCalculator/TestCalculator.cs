namespace TestCalculator;

using NUnit.Framework;
using Calculator;
using System.Collections.Generic;

public class TestCalculator
{
    Calculator calculator = new();

    [SetUp]
    public void Setup()
    {
        calculator = new();
    }

    private static IEnumerable<TestCaseData> Expressions() => new TestCaseData[]
    {
            new TestCaseData(null , ""),
            new TestCaseData("1", "1 + 2"),
            new TestCaseData("4", "4 *"),
            new TestCaseData("7", "7 = "),
            new TestCaseData("-7", "7 ±"),
            new TestCaseData("-12", "7 + 5 ±"),
            new TestCaseData("-7", "7 + ±"),
            new TestCaseData("-8", "7 + ± - 1 +"),
            new TestCaseData("7,6", "7 , 6 "),
            new TestCaseData("-7,1", "7 , 1 ± +"),
            new TestCaseData(null, " 1 1 C"),
            new TestCaseData("1", "1 - "),
            new TestCaseData("2", "4 √"),
            new TestCaseData("2", "4 √"),
            new TestCaseData("5", "4 + 21 √"),
            new TestCaseData(null, "4 ± √"),
            new TestCaseData(null, "4 ⌫"),
            new TestCaseData("4", "4 5 ⌫"),
            new TestCaseData(null, "⌫"),
            new TestCaseData(null, ","),
            new TestCaseData("5,6", "5 , 6"),
            new TestCaseData("5,6", "5 , 6 ,"),
            new TestCaseData(null, "5 / 0 -"),
            new TestCaseData("5", "5 / 0"),
            new TestCaseData("-2", "5 - 7 + 3"),
            new TestCaseData(null, "+"),
            new TestCaseData(null, "-"),
            new TestCaseData(null, "*"),
            new TestCaseData(null, "/"),
            new TestCaseData(null, "="),
            new TestCaseData("0", "0000123 - 123 +"),
            new TestCaseData("5", "6, - 1 +"),
            new TestCaseData("-1", "6, ± + 5 ="),
            new TestCaseData(null, " 1 C"),
            new TestCaseData(null, " 1 78 C"),

    };

    [TestCaseSource(nameof(Expressions))]
    public void Test1(string expectedValue, string value)
    {
        Assert.AreEqual(expectedValue, calculator.CalculateExpression(value.Split(' ')));
    }
}