namespace Sample.Struct.Equatables;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct ObjectComparer : IEqualityComparer<object>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public new bool Equals(object left, object right)
    {
        return left == right;
    }

    public int GetHashCode(object obj)
    {
        return obj.GetHashCode();
    }
}
