using Extensions;
using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dz4
{
    class Program
    {
        static string consoleRowsDelimeterString = new string('-', Console.WindowWidth);
        static IEnumerable<int> Squares(params int[] numbers)
        {
            foreach (var v in numbers.Where(p => p % 2 == 1))
                yield return v * v;
        }
        public static void Task1()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine($"Задание 1\nКоллекция: {numbers.GetString()}\nПосле метода Squares: {Squares(numbers).GetString()}\n{consoleRowsDelimeterString}\n");
        }
        public static void Task2()
        {
            var monthes = new Monthes();
            Console.WriteLine($"Задание 2\nТретий месяц: {monthes[3].ToString()}\nМесяцы в которых 30 дней: {monthes.GetMonthesByDaysCount(30).GetString()}\n{consoleRowsDelimeterString}\n");
        }
        public static void Task3()
        {
            var purchases = new Purchases
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
            Console.WriteLine($"Задание 3\nВсе приобретения:\n{purchases.GetString("\n")}\n\nВсё, что купил Иван Иванович:\n{purchases.GetCategoresByPurchaser("Иван Иванович").GetString(", ")}\n\nВсе, кто купили пылесос:\n{purchases.GetPurchasersByCategory("пылесос").GetString(", ")}\n{consoleRowsDelimeterString}\n");
        }
        public static void Task4()
        {
            // Create the link list.
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkList<string> list = new LinkList<string>(words);
            Console.WriteLine("The linked list values:\n" + list.ToString());
            Console.WriteLine($"sentence.Contains(\"jumped\") = {list.Contains("jumped")}\n");
            // Add the word 'today' to the beginning of the linked list.
            list.AddFirst("today");
            Console.WriteLine("Test 1: Add 'today' to beginning of the list:\n" + list.ToString() + "\n");

            // Move the first node to be the last node.
            LinkListNode<string> mark1 = list.First;
            list.RemoveFirst();
            list.AddLast(mark1);
            Console.WriteLine("Test 2: Move first node to be last node:\n" + list.ToString() + "\n");

            // Change the last node be 'yesterday'.
            list.RemoveLast();
            list.AddLast("yesterday");
            Console.WriteLine("Test 3: Change the last node to 'yesterday':\n" + list.ToString() + "\n");

            // Move the last node to be the first node.
            mark1 = list.Last;
            list.RemoveLast();
            list.AddFirst(mark1);
            Console.WriteLine("Test 4: Move last node to be first node:\n" + list.ToString() + "\n");


            // Indicate, by using parentheisis, the last occurence of 'the'.
            list.RemoveFirst();
            LinkListNode<string> current = list.FindLast("the");
            IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkListNode named current).
            list.AddAfter(current, "old");
            list.AddAfter(current, "lazy");
            IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = list.Find("fox");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            list.AddBefore(current, "quick");
            list.AddBefore(current, "brown");
            IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkListNode<string> mark2 = current.Previous;
            current = list.Find("dog");
            IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            list.Remove(mark1);
            list.AddBefore(current, mark1);
            IndicateNode(current, "Test 10: Move a referenced node (fox) before the current node (dog):");

            list.Remove(current);
            IndicateNode(current, "Test 11: Remove current node (dog) and attempt to indicate it:");

            list.AddAfter(mark2, current);
            IndicateNode(current, "Test 12: Add node removed in test 11 after a referenced node (brown):");

            list.Remove("old");
            Console.WriteLine("Test 13: Remove node that has the value 'old':\n" + list.ToString() + "\n");

            list.RemoveLast();
            ICollection<string> icoll = list;
            icoll.Add("rhinoceros");
            Console.WriteLine("Test 14: Remove last node, cast to ICollection, and add 'rhinoceros':\n" + list.ToString() + "\n");

            Console.WriteLine("Test 15: Copy the list to an array:");
            string[] sArray = new string[list.Count];
            list.CopyTo(sArray, 0);
            Console.WriteLine(sArray.GetString());

            list.Clear();

            Console.WriteLine($"\nTest 16: Clear linked list. Contains 'jumped' = {list.Contains("jumped")}");

            Console.ReadLine();
        }

        private static void IndicateNode(LinkListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
        //This code example produces the following output:
        //
        //The linked list values:
        //the fox jumped over the dog

        //Test 1: Add 'today' to beginning of the list:
        //today the fox jumped over the dog

        //Test 2: Move first node to be last node:
        //the fox jumped over the dog today

        //Test 3: Change the last node to 'yesterday':
        //the fox jumped over the dog yesterday

        //Test 4: Move last node to be first node:
        //yesterday the fox jumped over the dog

        //Test 5: Indicate last occurence of 'the':
        //the fox jumped over (the) dog

        //Test 6: Add 'lazy' and 'old' after 'the':
        //the fox jumped over (the) lazy old dog

        //Test 7: Indicate the 'fox' node:
        //the (fox) jumped over the lazy old dog

        //Test 8: Add 'quick' and 'brown' before 'fox':
        //the quick brown (fox) jumped over the lazy old dog

        //Test 9: Indicate the 'dog' node:
        //the quick brown fox jumped over the lazy old (dog)

        //Test 10: Throw exception by adding node (fox) already in the list:
        //Exception message: The LinkList node belongs a LinkList.

        //Test 11: Move a referenced node (fox) before the current node (dog):
        //the quick brown jumped over the lazy old fox (dog)

        //Test 12: Remove current node (dog) and attempt to indicate it:
        //Node 'dog' is not in the list.

        //Test 13: Add node removed in test 11 after a referenced node (brown):
        //the quick brown (dog) jumped over the lazy old fox

        //Test 14: Remove node that has the value 'old':
        //the quick brown dog jumped over the lazy fox

        //Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
        //the quick brown dog jumped over the lazy rhinoceros

        //Test 16: Copy the list to an array:
        //the
        //quick
        //brown
        //dog
        //jumped
        //over
        //the
        //lazy
        //rhinoceros

        //Test 17: Clear linked list. Contains 'jumped' = False
        //
        public static void Task5()
        {
            var dic = new ArrayList()
            {
                new Auto("Toyota Corolla", 180, 300000, 5, 1),
                new Auto("VAZ 2114i", 160, 220000, 0, 2),
                new Auto("Daewoo Nexia", 140, 260000, 5, 3),
                new Auto("Honda Torneo", 220, 400000, 7, 4),
                new Auto("Audi R8 Best", 360, 4200000, 3, 5)
            }.Cast<Auto>().ToArray();

            Console.WriteLine("Задание 5\nИсходный каталог автомобилей: \n" + dic.GetString("\n") + "\n");
            Array.Sort(dic);
            Console.WriteLine("Отсортированный каталог автомобилей: \n" + dic.GetString("\n") + $"\n{consoleRowsDelimeterString}\n");
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

            Console.WriteLine("Задание 6\nИсходный список: \n" + collect.GetString("\n") + "\n");
            Array.Sort(collect, (x, y) => (x.LastName + " " + x.FirstName).CompareTo(y.LastName + " " + y.FirstName));
            Console.WriteLine("Отсортированный список: \n" + collect.GetString("\n") + $"\n{consoleRowsDelimeterString}\n");
        }
        static void Main(string[] args)
        {
            //List<object> o = new List<object> { 1, "asd", 5.5 };
            //List<string> s = new List<string> { "qwe", "dsa", "ewq" };
            //(o as List<string>).Add("");    //контравариантность List<in T>
            //(o as List<string>).First();    //нельзя
            //(s as List<object>).Add(5);     //нельзя
            //(s as List<object>).First();    //ковариантность List<out T>

            //Task1();
            //Task2();
            //Task3();
            Task4();
            //Task5();
            //Task6();
            Console.ReadKey();
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
}