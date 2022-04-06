namespace Routers;

/// <summary>
/// A class for creating custom exceptions
/// </summary>
public class DisconnectedGraph : Exception
{
    public DisconnectedGraph(string? message) : base(message) { }
}
