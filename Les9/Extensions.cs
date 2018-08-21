using System.Linq;

namespace Les9
{
    public static class Extensions
    {
        public static bool In<T>(this T i, params T[] ints) => ints.Contains(i);
    }
}
