using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static string GetString<T>(this IEnumerable<T> collection, string delimiter = " ", string prefix = "", string postfix = "", string preMessage = "", string postMessage = "", string @default = "")
        {
            if (collection == null || !collection.Any())
                return preMessage + @default + postMessage;

            var builder = new StringBuilder(preMessage);

            foreach (var v in collection)
                builder.Append(prefix).Append(v?.ToString() ?? "null").Append(postfix).Append(delimiter);

            return builder.CutRight(delimiter.Length).Append(postMessage).ToString();
        }

        public static string Combine(this IEnumerable<string> @this, string @default = "")
        {
            if (@this == null || !@this.Any())
                return @default;

            var sb = new StringBuilder();
            foreach (var v in @this)
                sb.Append(v);

            return sb.ToString();
        }
    }
}
