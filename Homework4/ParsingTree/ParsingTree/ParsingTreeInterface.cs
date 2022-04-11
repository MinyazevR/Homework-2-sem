namespace ParsingTree;

/// <summary>
/// Parse Tree Interface
/// </summary>
public interface IParsingTree
{

    /// <summary>
    /// Function for printing a tree
    /// </summary>
    public void Print();

    /// <summary>
    /// Function for building a tree
    /// </summary>
    /// <param name="expression">The expression on the basis of which the tree is built</param>
    public void BuildTree(string expression);

    /// <summary>
    /// Function for calculating the value of an expression
    /// </summary>
    /// <returns>value of an expression</returns>
    public float Count();
}