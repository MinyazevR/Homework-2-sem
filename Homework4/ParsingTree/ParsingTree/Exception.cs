namespace Tree;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class InvalidCharacterException : Exception
{
    public InvalidCharacterException(string? message) : base(message) { }
}

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class DivideByZeroTreeException : Exception
{
    public DivideByZeroTreeException(string? message) : base(message) { }
}
