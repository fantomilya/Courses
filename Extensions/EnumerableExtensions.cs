using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static string GetString<T>(this IEnumerable<T> collection, string delimiter = " ", string prefix = "", string postfix = "", string preMessage = "", string postMessage = "", string defaultIfEmpty = "", Func<T, string> predicate = null)
        {
            if (collection == null || !collection.Any())
                return preMessage + defaultIfEmpty + postMessage;

            if (predicate == null)
                predicate = p => p.ToString();

            var builder = new StringBuilder(preMessage);

            foreach (var v in collection)
                builder.Append(prefix).Append(v == null? "null": predicate(v)).Append(postfix).Append(delimiter);

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

        #region -
        public static long GetStringTest1<T>(this IEnumerable<T> collection, string delimiter = " ", string prefix = "", string postfix = "", string preMessage = "", string postMessage = "", string @default = "", Func<T, string> predicate = null)
        {
            var sw = new Stopwatch();

            sw.Start();
            if (collection == null || !collection.Any())
            {
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }

            if (predicate == null)
                predicate = p => p.ToString();

            var builder = new StringBuilder(preMessage);

            foreach (var v in collection)
                builder.Append(prefix).Append(v == null ? "null" : predicate(v)).Append(postfix).Append(delimiter);

            var res = builder.CutRight(delimiter.Length).Append(postMessage).ToString();
            sw.Stop();
            return sw.ElapsedTicks;
        }
        public static long GetStringTest2<T>(this IEnumerable<T> collection, string delimiter = " ", string prefix = "", string postfix = "", string preMessage = "", string postMessage = "", string @default = "", Func<T, string> predicate = null)
        {
            var sw = new Stopwatch();

            sw.Start();
            if (collection == null || !collection.Any())
            {
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }

            if (predicate == null)
                predicate = p => p.ToString();

            var res = preMessage + collection.Select(p => $"{prefix} {predicate(p)} {postfix} {delimiter}").Combine().CutRight(delimiter.Length) + postMessage;
            sw.Stop();
            return sw.ElapsedTicks;
        }
        /*
            var l = Enumerable.Range(1, 15000);
            double t1 = 0, t2 = 0;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                GC.Collect();
                GC.WaitForFullGCComplete();
                t1 += l.GetStringTest1()/1000;

                GC.Collect();
                GC.WaitForFullGCComplete();

                t2 += l.GetStringTest2() / 1000;
            }
            Console.WriteLine($"{t1/100D:0.##}\n{t2/100D:0.##}");
        */
        #endregion
    }
}
