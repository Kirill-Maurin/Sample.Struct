using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sample.Struct.Equatables
{
    public struct IntComparer : IEqualityComparer<int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int left, int right) => left == right;

        public int GetHashCode(int obj) => obj.GetHashCode();
    }
}
