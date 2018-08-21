using System;
using System.Linq;

namespace Les8
{
    public static class Extensions
    {
        private static bool In<T>(this T i, params T[] ints) => ints.Contains(i);

        private static int Pow(this int i, int stepen) => (int)Math.Pow(i, stepen);
    }
}
