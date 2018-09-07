using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool Like(this string str, string search) => Regex.IsMatch(str, search.Replace("%", ".*"), RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static string CutRight(this string s, int count) => s.Substring(0, Math.Min(Math.Max(s.Length - count, 0), s.Length));

        public static string Repeat(this string s, int count) => Enumerable.Repeat(s, count).Combine();
    }
}
