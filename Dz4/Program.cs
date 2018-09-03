using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Program
    {
        static string s;
        static IEnumerable<int> Squares(params int[] numbers)
        {
            foreach (var v in numbers.Where(p => p % 2 == 1))
                yield return v * v;
        }
        public static void Task1()
        {
            var v = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine($"Коллекция: {v.GetString()}\nПосле метода Squares: {Squares(v).GetString()}\n{s}\n");
        }
        public static void Task2()
        {
            var m = new Monthes();
            Console.WriteLine($"Третий месяц: {m[3].ToString()}\nМесяцы в которых 30 дней: {m.GetMonthesByDaysCount(30).GetString()}\n{s}\n");
        }
        public static void Task3()
        {
            var p = new Purchases
            {
                { "Вася Пупкин", "машина" },
                { "Вася Пупкин", "квартира" },
                { "Вася Пупкин", "вертолет" },
                { "Вася Пупкин", "самолет" },
                { "Вася Пупкин", "пылесос" },
                { "Иван Иванович", "пылесос" },
                { "Иван Иванович", "самолет" },
                { "Иван Иванович", "вертолет" },
                { "Иван Иванович", "туфли" },
                { "Иван Иванович", "машина" },
                { "Семён Семёныч", "пылесос" }
            };
            Console.WriteLine($"Все приобретения:\n{p.GetString("\n")}\n\nВсё, что купил Иван Иванович:\n{p.GetCategoresByPurchaser("Иван Иванович").GetString(", ")}\n\nВсе, кто купили пылесос:\n{p.GetPurchasersByCategory("пылесос").GetString(", ")}\n{s}\n");
        }
        public static void Task4()
        {
            TwoSidedList<string> l = new TwoSidedList<string>();
            Console.WriteLine("Создали список");

            l.Add("new");
            Console.WriteLine("Add(\"new\");\n" + l.GetString(", ", "\"", "\"") + "\n");

            l.Add("Add");
            Console.WriteLine("Add(\"Add\");\n" + l.GetString(", ", "\"", "\"") + "\n");

            l.AddAfter("new", "AddAfter");
            Console.WriteLine("AddAfter(\"new\", \"AddAfter\");\n" + l.GetString(", ", "\"", "\"") + "\n");

            l.AddLast("AddLast");
            Console.WriteLine("AddLast(\"AddLast\");\n" + l.GetString(", ", "\"", "\"") + "\n");

            string[] s = new string[10];
            l.CopyTo(s, 3);
            Console.WriteLine("Копируем в новый массив размером 10, начиная с 3 \n" + s.GetString(", ", "\"", "\"") + "\n");

            l.Remove("Add");
            Console.WriteLine("Remove(\"Add\");\n" + l.GetString(", ", "\"", "\"") + "\n");

            l.Remove("AddLast");
            Console.WriteLine("Remove(\"AddLast\");\n" + l.GetString(", ", "\"", "\"") + $"\n{s}\n");
        }
        public static void Task5()
        {
            var dic = new List<Auto>
            {
                new Auto("Toyota Corolla", 180, 300000, 5, 1),
                new Auto("VAZ 2114i", 160, 220000, 0, 2),
                new Auto("Daewoo Nexia", 140, 260000, 5, 3),
                new Auto("Honda Torneo", 220, 400000, 7, 4),
                new Auto("Audi R8 Best", 360, 4200000, 3, 5)
            }.ToArray();
            Console.WriteLine("Исходный каталог автомобилей: \n" + dic.GetString("\n") + "\n");
            Array.Sort(dic);
            Console.WriteLine("Отсортированный каталог автомобилей: \n" + dic.GetString("\n") + $"\n{s}\n");
        }
        public static void Task6()
        {
            var collect = new List<Person>
            {
                new Person { FirstName = "Damon", LastName = "Hill" },
                new Person { FirstName = "Niki", LastName = "Lauda" },
                new Person { FirstName = "Ayrton", LastName = "Senna" },
                new Person { FirstName = "Graham", LastName = "Hill" },
                new Person { FirstName = "Damon", LastName = "Crauch" }
            }.ToArray();

            Console.WriteLine("Исходный список: \n" + collect.GetString("\n") + "\n");
            Array.Sort(collect, (x, y) => (x.LastName + " " + x.FirstName).CompareTo(y.LastName + " " + y.FirstName));
            Console.WriteLine("Отсортированный список: \n" + collect.GetString("\n") + $"\n{s}\n");
        }
        static void Main(string[] args)
        {
            s = new string('-', Console.WindowWidth);
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Console.ReadKey();
        }
    }
}
