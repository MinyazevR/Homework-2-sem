namespace TestStackCalculator;

using NUnit.Framework;
using Stack;
using System.Collections.Generic;
using StackCalculator;

/// <summary>
/// A class for testing a stack calculator
/// </summary>
public class TestsStackCalculator
{
    private Calculator stackCalculator = new();

    [SetUp]
    public void Setup()
    {
       stackCalculator = new Calculator();
    }

    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new StackOnArray<float>()),
            new TestCaseData(new StackOnLists<float>()),
        };

    [TestCaseSource(nameof(Stacks))]
    public void DevideByZero(IStack<float> stack)
    {
        string[] firstArray = { "123", "0", "/" };
        Assert.Throws<System.DivideByZeroException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void ExpressionFromInvalidCharacter(IStack<float> stack)
    {
        string[] firstArray = { "123", "0", "a" };
        Assert.Throws<InvalidCharacterException> (() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void FirstIncorrectExpression(IStack<float> stack)
    {
        string[] firstArray = { "123", "4", "*", "-" };
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void SecondIncorrectExpression(IStack<float> stack)
    {
        string[] firstArray = { "123", "4", "9", "23", "*", "-" };
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void ValidOneCharacterExpression(IStack<float> stack)
    {
       string[] firstArray = { "12"};
       Assert.AreEqual(12, stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }


    [TestCaseSource(nameof(Stacks))]
    public void ValidExpressionFromZeros(IStack<float> stack)
    {
        string[] firstArray = { "0", "0", "+", "0", "-" };
        Assert.AreEqual(0, stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void ExpressionWithoutNumbers(IStack<float> stack)
    {
        string[] firstArray = {"+", "-"};
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void EmptyString(IStack<float> stack)
    {
        string[] firstArray = {" "};
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void LongExpression(IStack<float> stack)
    {
        string[] firstArray = { "0" , "120", "+", "45", "15", "/", "33", "+", "-5", "-13", "+", "9", "/", "/", "1", "123", "*", "+", "-" };
        Assert.AreEqual(15, stackCalculator?.CountTheExpressionInPostfixForm(firstArray, stack));
    }
}