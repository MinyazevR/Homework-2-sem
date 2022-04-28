namespace Queue;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class EmptyQueueException : Exception
{
    public EmptyQueueException() : base() { }
}