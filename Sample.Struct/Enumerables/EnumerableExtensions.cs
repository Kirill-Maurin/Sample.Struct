using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class EnumerableExtensions
    {
        public static int Sum<TEnumerator, TEnumerable>(this Enumerable<int, TEnumerator, TEnumerable> enumerable)
            where TEnumerator: IEnumerator<int>
            where TEnumerable: IEnumerable<int, TEnumerator>
        {
            var result = 0;
            foreach(var i in enumerable)
                result += i;
            return result;
        }
    }
}