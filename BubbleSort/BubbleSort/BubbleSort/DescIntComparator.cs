namespace Sort;

using System.Collections.Generic;

public class DescIntComparator : IComparer<int>
{
    int IComparer<int>.Compare(int x, int y) => y - x;
}