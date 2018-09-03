using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    public static class Extensions
    {
        public static string GetString<T>(this IEnumerable<T> collection, string delimiter = " ", string preString = "", string postString = "")
        {
            string result = collection.Select(p => preString + (p?.ToString() ?? "null") + postString + delimiter).DefaultIfEmpty(delimiter).Aggregate(string.Concat);
            return result.Substring(0, result.Length - delimiter.Length);
        }
    }
}
