using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Program
    {
        static IEnumerable<int> Squares(params int[] numbers)
        {
            foreach (var v in numbers.Where(p => p % 2 == 1))
                yield return v * v;
        }
        static void Main(string[] args)
        {
            #region 1
            //Console.WriteLine(Squares(1, 2, 3, 4, 5, 6, 7, 8).GetString());
            #endregion
            #region 2
            //var m = new Monthes();
            //Console.WriteLine(m[3] + "\n" + m.GetMonthesByDaysCount(30).GetString());
            #endregion
            #region 3
            //var p = new Purchases
            //{
            //    { "Вася Пупкин", "машина" },
            //    { "Вася Пупкин", "квартира" },
            //    { "Вася Пупкин", "вертолет" },
            //    { "Вася Пупкин", "самолет" },
            //    { "Вася Пупкин", "пылесос" },
            //    { "Иван Иванович", "пылесос" },
            //    { "Иван Иванович", "самолет" },
            //    { "Иван Иванович", "вертолет" },
            //    { "Иван Иванович", "туфли" },
            //    { "Иван Иванович", "машина" },
            //    { "Семён Семёныч", "пылесос" }
            //};
            //Console.WriteLine(p.GetCategoresByPurchaser("Иван Иванович").GetString());
            //Console.WriteLine(p.GetPurchasersByCategory("пылесос").GetString());
            #endregion
            #region 4
            //TwoSidedList<string> l = new TwoSidedList<string>();
            //Console.WriteLine(l);
            //l.Add("new");
            //Console.WriteLine(l);
            //l.Add("Add");
            //Console.WriteLine(l);
            //l.AddAfter("new", "AddAfter");
            //Console.WriteLine(l);
            //l.AddLast("AddLast");
            //Console.WriteLine(l);
            //var t = l[3];
            //l.Remove("Add");
            //string[] s = new string[25];
            //l.CopyTo(s, 3);
            //Console.WriteLine(l);
            //l.Remove("AddLast");
            //Console.WriteLine(l);
            #endregion
            Console.ReadKey();
        }
    }
}
