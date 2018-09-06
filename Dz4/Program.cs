﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    internal class Program
    {
        private static readonly string ConsoleRowsDelimeterString = new string('-', Console.WindowWidth);

        private static IEnumerable<int> Squares(params int[] numbers)
        {
            foreach (int number in numbers.Where(p => p % 2 == 1))
                yield return number * number;
        }

        public static void Task1()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine($"Задание 1\nКоллекция: {numbers.GetString()}\nПосле метода Squares: {Squares(numbers).GetString()}\n{ConsoleRowsDelimeterString}\n");
        }
        public static void Task2()
        {
            Monthes monthes = new Monthes();
            Console.WriteLine($"Задание 2\nТретий месяц: {monthes[3].ToString()}\nМесяцы в которых 30 дней: {monthes.GetMonthesByDaysCount(30).GetString()}\n{ConsoleRowsDelimeterString}\n");
        }
        public static void Task3()
        {
            Purchases purchases = new Purchases
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
            Console.WriteLine($"Задание 3\nВсе приобретения:\n{purchases.GetString("\n")}\n\nВсё, что купил Иван Иванович:\n{purchases.GetCategoresByPurchaser("Иван Иванович").GetString(", ")}\n\nВсе, кто купили пылесос:\n{purchases.GetPurchasersByCategory("пылесос").GetString(", ")}\n{ConsoleRowsDelimeterString}\n");
        }
        public static void Task4()
        {
            MyLinkedList<string> linkedList = new MyLinkedList<string>();
            Console.WriteLine("Задание 4\nСоздали список");

            linkedList.Add("new");
            Console.WriteLine("Add(\"new\");\n" + linkedList.GetString(", ", "\"", "\"") + "\n");

            linkedList.Add("Add");
            Console.WriteLine("Add(\"Add\");\n" + linkedList.GetString(", ", "\"", "\"") + "\n");

            linkedList.AddAfter("new", "AddAfter");
            Console.WriteLine("AddAfter(\"new\", \"AddAfter\");\n" + linkedList.GetString(", ", "\"", "\"") + "\n");

            linkedList.Insert(0, "Insert");
            Console.WriteLine("Insert(0, \"Insert\");\n" + linkedList.GetString(", ", "\"", "\"") + "\n");

            string[] s = new string[10];
            linkedList.CopyTo(s, 4);
            Console.WriteLine("Копируем в новый массив размером 10, начиная с 9 \n" + s.GetString(", ", "\"", "\"") + "\n");

            linkedList.Remove("Add");
            Console.WriteLine("Remove(\"Add\");\n" + linkedList.GetString(", ", "\"", "\"") + "\n");

            linkedList.RemoveAt(1);
            Console.WriteLine("RemoveAt(1);\n" + linkedList.GetString(", ", "\"", "\"") + $"\n{ConsoleRowsDelimeterString}\n");
        }
        public static void Task5()
        {
            Auto[] dic =
            {
                new Auto("Toyota Corolla", 180, 300000, 5, 1),
                new Auto("VAZ 2114i", 160, 220000, 0, 2),
                new Auto("Daewoo Nexia", 140, 260000, 5, 3),
                new Auto("Honda Torneo", 220, 400000, 7, 4),
                new Auto("Audi R8 Best", 360, 4200000, 3, 5)
            };

            Console.WriteLine("Задание 5\nИсходный каталог автомобилей: \n" + dic.GetString("\n") + "\n");
            Array.Sort(dic);
            Console.WriteLine("Отсортированный каталог автомобилей: \n" + dic.GetString("\n") + $"\n{ConsoleRowsDelimeterString}\n");
        }
        public static void Task6()
        {
            Person[] collect =
            {
                new Person { FirstName = "Damon", LastName = "Hill" },
                new Person { FirstName = "Niki", LastName = "Lauda" },
                new Person { FirstName = "Ayrton", LastName = "Senna" },
                new Person { FirstName = "Graham", LastName = "Hill" },
                new Person { FirstName = "Damon", LastName = "Crauch" }
            };

            Console.WriteLine("Задание 6\nИсходный список: \n" + collect.GetString("\n") + "\n");
            Array.Sort(collect, (x, y) => (x.LastName + " " + x.FirstName).CompareTo(y.LastName + " " + y.FirstName));
            Console.WriteLine("Отсортированный список: \n" + collect.GetString("\n") + $"\n{ConsoleRowsDelimeterString}\n");
        }

        private static void Main()
        {
            //List<object> o = new List<object> { 1, "asd", 5.5 };
            //List<string> s = new List<string> { "qwe", "dsa", "ewq" };
            //(o as List<string>).Add("");    //контравариантность List<in T>
            //(o as List<string>).First();    //нельзя
            //(s as List<object>).Add(5);     //нельзя
            //(s as List<object>).First();    //ковариантность List<out T>

            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Console.ReadKey();
        }
    }
    /*
     * Dictionary<T, K>: Hashtable(порядок не сохраняется) ListDictionary(быстро для <10 элементов, порядок сохраняется) HybridDictionary(ListDictionary, но при >10 преобразуется в Hashtable(долго)) OrderedDictionary(типо HashTable + методы ArrayList(индексатор))
                         SortedList<T,K>(доступ по индеску, но медленнее при вставке, чем SortedDictionary<T,K>)
     List<T>: ArrayList
     
     Stack - LIFO
     Queue - FIFO
     BitArray(для булов, есть методы для побитовых операций)
     HashSet<T>(не отсортирован, использует хеш-таблицу только ключей), SortedSet<T>(отсортирован, использует черно-красное дерево) - быстрый хешированный поиск, нет доступа по позиции (как типизированный HashTable без значений)
     
     */
}