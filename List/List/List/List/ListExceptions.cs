namespace List;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class RepeatValueException : Exception
{
    public RepeatValueException(string? message) : base(message) { }
}

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class RemoveNonExistenElementException : Exception
{
    public RemoveNonExistenElementException(string? message) : base(message) { }
}