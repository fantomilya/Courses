using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class OtherExtensions
    {
        public static bool In<T>(this T item, params T[] ints) => ints.Contains(item);

        public static bool Between<T>(this T item, T left, T right, bool includeLeft = true, bool includeRight = true) where T : IComparable<T> =>
            item.CompareTo(left) >= (includeLeft ? 0 : 1) && item.CompareTo(right) <= (includeRight ? 0 : 1);

        public static bool Between<T>(this T item, T left, T right, IComparer<T> comparer, bool includeLeft = true, bool includeRight = true) =>
            comparer.Compare(item, left) >= (includeLeft ? 0 : 1) && comparer.Compare(item, right) <= (includeRight ? 0 : 1);
    }
}
