using Extensions;
using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz5
{
    class Program
    {
        public static void TaskList()
        {
            void IndicateNode(LinkListNode<string> node, string test)
            {
                if (node.List == null)
                {
                    Console.WriteLine($"Node '{node.Value}' is not in the list.\n");
                    return;
                }

                var value = node.Value;
                node.Value = $"({node.Value})";

                Console.WriteLine(node.List.GetString(preMessage:test + "\n") + "\n");
                node.Value = value;
            }
            // Create the link list.
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkList<string> list = new LinkList<string>(words);
            Console.WriteLine("The linked list values:\n" + list.ToString() + "\n");
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
            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
        }
        static void TaskFish()
        {
            var duplicates = new Hashtable(new InsensitiveComparer() as IEqualityComparer);
            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");
            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";
            Console.WriteLine(duplicates.Cast<DictionaryEntry>().GetString(", ", "\"", "\"", "", postMessage: $". (Count={duplicates.Count})", predicate: p => p.Value.ToString()));
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
        static void TaskEmployee()
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

        static void Main(string[] args)
        {
            //TaskList();
            //TaskFish();
            //TaskEmployee();
            Console.ReadKey(true);
        }
    }
}
