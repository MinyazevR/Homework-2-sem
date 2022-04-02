using NUnit.Framework;
using StackCalculator;
using System;

namespace TestStackCalculator;

/// <summary>
/// A class for testing a stack calculator
/// </summary>
public class TestsStackCalculator
{
    Calculator? stackCalculator;
    [SetUp]
    public void Setup()
    {
       stackCalculator = new Calculator();
    }

    [Test]
    public void DevideByZero()
    {
        string[] firstArray = { "123", "0", "/" };
        Assert.Throws<System.DivideByZeroException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void ExpressionFromInvalidCharacter()
    {
        string[] firstArray = { "123", "0", "a" };
        Assert.Throws<InvalidCharacterException> (() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void FirstIncorrectExpression()
    {
        string[] firstArray = { "123", "4", "*", "-" };
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void SecondIncorrectExpression()
    {
        string[] firstArray = { "123", "4", "9", "23", "*", "-" };
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void ValidOneCharacterExpression()
    {
       string[] firstArray = { "12"};
       Assert.AreEqual(12, stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }


    [Test]
    public void ValidExpressionFromZeros()
    {
        string[] firstArray = { "0", "0", "+", "0", "-" };
        Assert.AreEqual(0, stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void ExpressionWithoutNumbers()
    {
        string[] firstArray = {"+", "-"};
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void EmptyString()
    {
        string[] firstArray = {" "};
        Assert.Throws<IncorrectExpressionException>(() => stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }

    [Test]
    public void LongExpression()
    {
        string[] firstArray = { "0" , "120", "+", "45", "15", "/", "33", "+", "-5", "-13", "+", "9", "/", "/", "1", "123", "*", "+", "-" };
        Assert.AreEqual(15, stackCalculator?.CountTheExpressionInPostfixForm(firstArray));
    }
}