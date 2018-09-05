using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static string GetString<T>(this IEnumerable<T> collection, string delimiter = " ", string prefix = "", string postfix = "", string preMessage = "", string postMessage = "")
        {
            string result = collection.Select(p => prefix + (p?.ToString() ?? "null") + postfix + delimiter).DefaultIfEmpty(delimiter).Aggregate(string.Concat);
            return preMessage + result.Substring(0, result.Length - delimiter.Length) + postMessage;
        }
    }
}
