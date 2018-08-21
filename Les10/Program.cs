using System;

namespace Les10
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int> { 1, 2, 3, 4, 5 };
            list.RemoveAt(0);
            list.Insert(1, 0);
            list.AddRange(6, 7);
            list.Add(8);
            list.Remove(3);
            list.Add(3);
            MyList<int> sortedList = list.Sort(SortDiraction.Descending);
            Store d = new Store();
            d.Add(new Article("ываыва", "ывыва", 11));

            do
            {
                Console.WriteLine("Введите название");
                Console.WriteLine(d[Console.ReadLine()] + "\nОжидание кнопки...для выхода нажмите Esc");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.ReadKey(true);
        }
    }
}