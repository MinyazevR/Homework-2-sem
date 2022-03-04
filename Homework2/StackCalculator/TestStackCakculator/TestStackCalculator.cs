using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator;

namespace TestStackCalculator;

// A class for implementing stack calculator testing
[TestClass]
public class TestStackCalculator 
{
    // Testing a function for calculating an arithmetic expression
    [TestMethod]
    public void FirstTestForArithmeticExpression()
    {
        Calculator stackCalculator = new Calculator();
        string[] firstArray = { "123", "41", "/", "3", "2", "+", "-"};
        Assert.AreEqual(stackCalculator.CountTheExpressionInPostfixForm(firstArray), -2);
        string[] secondArray = { "1", "2", "3", "+", "*"};
        Assert.AreEqual(stackCalculator.CountTheExpressionInPostfixForm(secondArray), 5);
        string[] thirdArray = { "1", "12", "-364", "7", "/", "+", "/" };
        Assert.AreEqual(stackCalculator.CountTheExpressionInPostfixForm(thirdArray), -0,025);
        string[] fourthArray = { "1", "10", "-2", "7", "*", "+", "/" };
        Assert.AreEqual(stackCalculator.CountTheExpressionInPostfixForm(fourthArray), -0,25);
        string[] fifthArray = {"24", "-12", "-72", "-3", "/", "+", "/" };
        Assert.AreEqual(stackCalculator.CountTheExpressionInPostfixForm(fifthArray), 2);
    }
}