using System;
using System.Linq;

namespace Dz7
{
    class Program
    {
        /*
         * принимает в качестве аргумента массив делегатов и возвращает среднее арифметическое возвращаемых  значений методов сообщенных с делегатами в массиве.
         */
        static readonly Random Rand = new Random();
        static void Main()
        {
            Func<Func<int>[], double> m = arr => arr.Average(p=>p());
            Func<int> getRand = () => Rand.Next(-100, 101);
            Console.WriteLine(m(new[] { getRand, getRand, getRand }).ToString("0.##") + "\n" + new string('-', Console.WindowWidth));

            Console.WriteLine($"{Adapter.GetInfoPrinter(new Facebook("лол", 11, 3))}\n{Adapter.GetInfoPrinter(new Twitter("пыщ", 18, 20))}\n{Adapter.GetInfoPrinter(new Vk("тратата", 25, 100))}");
        
            Console.ReadKey(true);
        }
    }
}