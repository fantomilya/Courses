using System.Text;

namespace Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder CutRight(this StringBuilder s, int count) => s.Remove(s.Length - count, count);
    }
}
