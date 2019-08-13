using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sample.Struct.Equatables
{

    public struct ObjectComparer : IEqualityComparer<object>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(object left, object right) => left == right;

        public int GetHashCode(object obj) => obj.GetHashCode();
    }
}
