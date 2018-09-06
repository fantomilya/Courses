using System;

namespace Extensions
{
    public static class ArrayExtesions
    {
        public static T Max<T>(this T[,] arr)
        where T : IComparable<T>
        {
            T max = arr[0, 0];
            foreach (T v in arr)
                if (v.CompareTo(max) > 0)
                    max = v;

            return max;
        }

        public static T Max<T>(this T[][] arr)
            where T : IComparable<T>
        {
            var max = arr[0][0];
            foreach (var v in arr)
                foreach (var v1 in v)
                    if (max.CompareTo(v1) < 0)
                        max = v1;

            return max;
        }

        public static Random Rand = new Random();

        public static int[,] FillRand(this int[,] arr, int minValue = -99, int maxValue = 99)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = Rand.Next(minValue, maxValue);

            return arr;
        }

        public static string AsString<T>(this T[,] arr)
        where T : IComparable<int>
        {
            int n = 0;
            bool existsNegative = false;
            foreach (var v in arr)
            {
                if (n < v.ToString().Length)
                    n = v.ToString().Length;

                if (v.CompareTo(0) < 0)
                    existsNegative = true;
            }

            string res = string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    res += arr[i, j].ToString().PadRight(arr[i, j].CompareTo(0) >= 0 && existsNegative ? n : n + 1, ' ').PadLeft(n + 1, ' ');

                res = res.TrimEnd(' ') + "".PadRight((n + 1) / 2, '\n');
            }

            return res;
        }
    }
}
