namespace Stack;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class StackException : Exception
{
    public StackException(string? message) : base(message) { }
}
