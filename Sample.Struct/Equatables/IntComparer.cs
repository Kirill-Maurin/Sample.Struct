namespace Sample.Struct.Equatables;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct IntComparer : IEqualityComparer<int>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(int left, int right)
    {
        return left == right;
    }

    public int GetHashCode(int obj)
    {
        return obj.GetHashCode();
    }
}
