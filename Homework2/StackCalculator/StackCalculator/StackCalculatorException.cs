namespace StackCalculator;

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
public class IncorrectExpressionException : Exception
{
    public IncorrectExpressionException(string? message) : base(message) { }
}
