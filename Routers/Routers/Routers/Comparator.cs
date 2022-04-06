namespace Routers;

using System.Collections.Generic;

public class Comparator : IComparer<int>
{
    int IComparer<int>.Compare(int x, int y)
    {
        if (x > y)
        {
            return -1;
        }
        else if (x == y)
        {
            return 0;
        }
        return 1;
    }
}

