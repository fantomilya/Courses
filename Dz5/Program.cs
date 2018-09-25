using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using LinkList;

namespace Dz5
{
    internal class Program
    {
        public static void TaskList()
        {
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkList<string> list = new LinkList<string>(words);
            Console.WriteLine("The linked list values:\n" + list + "\n");
            Console.WriteLine($"sentence.Contains(\"jumped\") = {list.Contains("jumped")}\n");
            list.AddFirst("today");
            Console.WriteLine("Test 1: Add 'today' to beginning of the list:\n" + list + "\n");

            LinkListNode<string> mark1 = list.First;
            list.RemoveFirst();
            list.AddLast(mark1);
            Console.WriteLine("Test 2: Move first node to be last node:\n" + list + "\n");

            list.RemoveLast();
            list.AddLast("yesterday");
            Console.WriteLine("Test 3: Change the last node to 'yesterday':\n" + list + "\n");

            mark1 = list.Last;
            list.RemoveLast();
            list.AddFirst(mark1);
            Console.WriteLine("Test 4: Move last node to be first node:\n" + list + "\n");


            list.RemoveFirst();
            LinkListNode<string> current = list.FindLast("the");

            list.AddAfter(current, "old");
            list.AddAfter(current, "lazy");

            current = list.Find("fox");

            list.AddBefore(current, "quick");
            list.AddBefore(current, "brown");

            mark1 = current;
            LinkListNode<string> mark2 = current.Previous;
            current = list.Find("dog");

            list.Remove(mark1);
            list.AddBefore(current, mark1);

            list.Remove(current);

            list.AddAfter(mark2, current);

            list.Remove("old");
            Console.WriteLine("Test 13: Remove node that has the value 'old':\n" + list + "\n");

            list.RemoveLast();
            ICollection<string> icoll = list;
            icoll.Add("rhinoceros");
            Console.WriteLine("Test 14: Remove last node, cast to ICollection, and add 'rhinoceros':\n" + list + "\n");

            Console.WriteLine("Test 15: Copy the list to an array:");
            string[] sArray = new string[list.Count];
            list.CopyTo(sArray, 0);
            Console.WriteLine(sArray.GetString());

            list.Clear();

            Console.WriteLine($"\nTest 16: Clear linked list. Contains 'jumped' = {list.Contains("jumped")}");
            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
        }

        private static void TaskFish()
        {
            var duplicates = new Hashtable(new InsensitiveComparer() as IEqualityComparer);
            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");
            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";
            Console.WriteLine(duplicates.Cast<DictionaryEntry>().GetString(", ", "\"", "\"", "", $". (Count={duplicates.Count})", predicate: p => p.Value.ToString()));
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        private static void TaskEmployee()
        {
            Dictionary<EmployeeId, Employee> employees = new Dictionary<EmployeeId, Employee>(31);
            EmployeeId idTony = new EmployeeId("C3755");
            Employee tony = new Employee(idTony, "Tony Stewart", 379025.00m);
            employees.Add(idTony, tony);
            Console.WriteLine(tony);
            EmployeeId idCarl = new EmployeeId("F3547");
            Employee carl = new Employee(idCarl, "Carl Edwards", 403466.00m);
            employees.Add(idCarl, carl);
            Console.WriteLine(carl);
            EmployeeId idKevin = new EmployeeId("C3386");
            Employee kevin = new Employee(idKevin, "Kevin Harwick", 415261.00m);
            employees.Add(idKevin, kevin);
            Console.WriteLine(kevin);
            EmployeeId idMatt = new EmployeeId("F3323");
            Employee matt = new Employee(idMatt, "Matt Kenseth", 1589390.00m);
            employees[idMatt] = matt;
            Console.WriteLine(matt);
            EmployeeId idBrad = new EmployeeId("D3234");
            Employee brad = new Employee(idBrad, "Brad Keselowski", 322295.00m);
            employees[idBrad] = brad;
            Console.WriteLine(brad);

            while (true)
            {
                Console.Write("Enter employee id (X to exit)> "); // Запрос идентификатора
                // сотрудника
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "X")
                    break;

                try
                {
                    EmployeeId id = new EmployeeId(userInput);

                    if (employees.TryGetValue(id, out Employee employee))
                        Console.WriteLine(employee);
                    else
                        Console.WriteLine($"Employee with id {id.ToString()} does not exist");
                }
                catch (EmployeeldException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
        }

        private static void Main(string[] args)
        {
            //TaskList();
            //TaskFish();
            //TaskEmployee();
            Console.ReadKey(true);
        }
    }
}
