namespace sparseVector;

public interface IVector
{
    public Vector Add(Vector firstVector, Vector secondVector);

    public Vector Subtract(Vector firstVector, Vector secondVector);

    public bool IsNullVector(Vector vector);

    public float CalculateScalarProduct(Vector firstVector, Vector secondVector);
}
