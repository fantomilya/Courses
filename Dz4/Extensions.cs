using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz4
{
    public static class Extensions
    {
        public static string GetString<T>(this IEnumerable<T> collection)
        {
            string result = collection.Select(p => p.ToString() + " ").DefaultIfEmpty(" ").Aggregate(string.Concat);
            return result.Substring(0, result.Length - 1);
        }
    }
}
