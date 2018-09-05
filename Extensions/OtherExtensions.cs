using System.Linq;

namespace Extensions
{
    public static class OtherExtensions
    {
        public static bool In<T>(this T i, params T[] ints) => ints.Contains(i);
    }
}
