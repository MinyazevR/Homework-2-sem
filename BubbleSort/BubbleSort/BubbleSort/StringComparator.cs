namespace Sort;

using System.Collections.Generic;

public class StringComparator : IComparer<string>
{
    int IComparer<string>.Compare(string? x, string? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException();
        }
        return x.CompareTo(y);
    }
}

