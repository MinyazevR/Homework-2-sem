using System;

namespace Tree;

/// <summary>
/// Parse Tree Interface
/// </summary>
public interface IParsingTree
{
    /// <summary>
    /// Function for deleting a tree
    /// </summary>
    public void DeleteTree();

    /// <summary>
    /// Function for printing a tree
    /// </summary>
    public string PrintTree();

    /// <summary>
    /// Function for building a tree
    /// </summary>
    /// <param name="expression">The expression on the basis of which the tree is built</param>
    public void BuildTree(string expression);

    /// <summary>
    /// Function for traversing the tree
    /// </summary>
    public float TreeTraversal();
}