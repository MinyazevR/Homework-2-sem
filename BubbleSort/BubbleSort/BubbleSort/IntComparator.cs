namespace Sort;

using System.Collections.Generic;

public class IntComparator : IComparer<int>
{
    int IComparer<int>.Compare(int x, int y) => x - y;
}
