namespace VectorTest;

using NUnit.Framework;
using sparseVector;
using System.Collections.Generic;

public class VectorTest
{
    Vector firstVector = new Vector(new(), 0);
    Vector secondVector = new Vector(new(), 0);

    private void InitializeVectorDictionary(Dictionary <ulong, float> dictionary, ulong index, float value)
    {
        dictionary.Add(index, value);
    }

    [SetUp]
    public void Setup()
    {
        Dictionary<ulong, float> firstDictionary = new();

        InitializeVectorDictionary(firstDictionary, 0, 1);
        InitializeVectorDictionary(firstDictionary, 3, 4);
        InitializeVectorDictionary(firstDictionary, 4, -4);
        InitializeVectorDictionary(firstDictionary, 6, 8);
        InitializeVectorDictionary(firstDictionary, 10, 1);
        firstVector = new(firstDictionary, 12);

        Dictionary<ulong, float> secondDictionary = new();

        InitializeVectorDictionary(secondDictionary, 2, 1);
        InitializeVectorDictionary(secondDictionary, 3, -4);
        InitializeVectorDictionary(secondDictionary, 4, 2);
        InitializeVectorDictionary(secondDictionary, 5, 12);
        InitializeVectorDictionary(secondDictionary, 6, 8);
        InitializeVectorDictionary(secondDictionary, 11, 7);

        secondVector = new(secondDictionary, 12);
    }

    [Test]
    public void ShouldExpetcedTrueWhenAddTwoNonZeroVectorWithSameLength()
    {
        Dictionary<ulong, float> answer = new();
        InitializeVectorDictionary(answer, 0, 1);
        InitializeVectorDictionary(answer, 2, 1);
        InitializeVectorDictionary(answer, 4, -2);
        InitializeVectorDictionary(answer, 5, 12);
        InitializeVectorDictionary(answer, 6, 16);
        InitializeVectorDictionary(answer, 10, 1);
        InitializeVectorDictionary(answer, 11, 7);
        Assert.IsTrue(Vector.IsEqualVectors(new Vector(answer, 12), Vector.Add(firstVector, secondVector)));
    }

    [Test]
    public void ShouldExpetcedTrueWhenIsZeroVectorFromZeroVector()
    {
        Assert.IsTrue(Vector.IsZeroVector(new Vector(new(), 12)));
    }

    [Test]
    public void ShouldExpetcedZeroVectorWhenSubstractEqualsVectors()
    {
        var copyFirstVector = Vector.MakeCopyTheVector(firstVector);
        var copySecondVector = Vector.MakeCopyTheVector(secondVector);

        Assert.IsTrue(Vector.IsZeroVector(Vector.Subtract(firstVector, copyFirstVector)));
        Assert.IsTrue(Vector.IsZeroVector(Vector.Subtract(secondVector, copySecondVector)));
    }

    [Test]
    public void ShouldExpetced0WhenCalculateScalarProduct()
    {
        Assert.AreEqual(0, Vector.CalculateScalarProduct(new Vector(new(), 12), new Vector(new(), 12)));
    }

    [Test]
    public void ShouldExpetcedRightAnswerWhenCalculateScalarProduct()
    {
        Assert.AreEqual(40, Vector.CalculateScalarProduct(firstVector, secondVector));
    }
}
