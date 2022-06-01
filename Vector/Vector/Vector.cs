namespace sparseVector;

using System;

public class Vector
{
    private Dictionary<ulong, float> Coordinates { get; set; }
    private ulong NumberOfElements { get; set; }

    /// <summary>
    /// The information about the vector that we need is a dictionary 
    /// consisting of indexes of non-zero coordinates and their values,
    /// as well as the dimension of the basis of the space in which the vector is located
    /// </summary>
    public Vector (Dictionary<ulong, float> dictionary, ulong numberOfCoordinates)
    {
        this.NumberOfElements = numberOfCoordinates;
        this.Coordinates = dictionary;
    }

    /// <summary>
    /// Function for adding two vectors
    /// </summary>
    /// <param name="firstVector">First vector</param>
    /// <param name="secondVector">Second Vector</param>
    /// <returns>A vector equal to the sum of two vectors</returns>
    /// <exception cref="ArgumentException"></exception>
    public static Vector Add(Vector firstVector, Vector secondVector)
    {
        if (firstVector.NumberOfElements != secondVector.NumberOfElements)
        {
            throw new ArgumentException();
        }
        foreach (ulong keys in firstVector.Coordinates.Keys)
        {
            if (secondVector.Coordinates.ContainsKey(keys))
            {
                firstVector.Coordinates[keys] += secondVector.Coordinates[keys];
                if (firstVector.Coordinates[keys] == 0)
                {
                    firstVector.Coordinates.Remove(keys);
                }
                secondVector.Coordinates.Remove(keys);
            }
        }
        foreach (ulong keys in secondVector.Coordinates.Keys)
        {
            firstVector.Coordinates.Add(keys, secondVector.Coordinates[keys]);
        }
        return firstVector;
    }

    /// <summary>
    /// Function for subtracting vectors
    /// </summary>
    /// <param name="firstVector">The vector from which to subtract</param>
    /// <param name="secondVector">The vector to be subtracted</param>
    /// <returns>Vector equal to the difference of the first and second</returns>
    public static Vector Subtract(Vector firstVector, Vector secondVector)
    {
        if (firstVector.NumberOfElements != secondVector.NumberOfElements)
        {
            throw new ArgumentException();
        }
        foreach (ulong keys in firstVector.Coordinates.Keys)
        {
            if (secondVector.Coordinates.ContainsKey(keys))
            {
                firstVector.Coordinates[keys] -= secondVector.Coordinates[keys];
                if (firstVector.Coordinates[keys] == 0)
                {
                    firstVector.Coordinates.Remove(keys);
                }
                secondVector.Coordinates.Remove(keys);
            }
        }
        foreach (ulong keys in secondVector.Coordinates.Keys)
        {
            firstVector.Coordinates.Add(keys, secondVector.Coordinates[keys]*(-1));
        }
        return firstVector;
    }

    /// <summary>
    /// Function for checking the vector for 0
    /// </summary>
    /// <param name="vector">The vector that needs to be checked for whether it is zero</param>
    /// <returns>Is the vector zero</returns>
    public static bool IsZeroVector(Vector vector) => vector.Coordinates.Count == 0;

    /// <summary>
    /// Function for finding scalar product of two vectors
    /// </summary>
    /// <param name="firstVector">First vector</param>
    /// <param name="secondVector">Second Vector</param>
    /// <returns>Scalar product</returns>
    /// <exception cref="ArgumentException"></exception>
    public static float CalculateScalarProduct(Vector firstVector, Vector secondVector)
    {
        if (firstVector.NumberOfElements != secondVector.NumberOfElements)
        {
            throw new ArgumentException();
        }
        if (IsZeroVector(firstVector) && IsZeroVector(secondVector))
        {
            return 0;
        }
        float result = 0;
        foreach (ulong keys in firstVector.Coordinates.Keys)
        {
            if (secondVector.Coordinates.ContainsKey(keys))
            {
                result += firstVector.Coordinates[keys] * secondVector.Coordinates[keys];
            }
        }
        return result;
    }

    /// <summary>
    /// Function for checking the equality of vectors
    /// </summary>
    public static bool IsEqualVectors(Vector firstVector, Vector secondVector)
    {
        if (firstVector.NumberOfElements != secondVector.NumberOfElements)
        {
            return false;
        }
        Vector newfirstVector = MakeCopyTheVector(firstVector);
        Vector newsecondVector = MakeCopyTheVector(secondVector);
        var answer = Subtract(newfirstVector, newsecondVector);
        return answer.Coordinates.Count == 0;
    }

    /// <summary>
    /// Function to create a copy of a vector
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Vector MakeCopyTheVector(Vector vector)
    {
        return new(vector.Coordinates, vector.NumberOfElements);
    }
}