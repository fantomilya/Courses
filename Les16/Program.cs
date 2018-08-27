using System;
using System.Diagnostics;

namespace Structure
{
    class Program
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0, j = 0; i < 2000; i++, j++)
                Console.WriteLine("{0}\t{1}", i, j);

            sw.Stop();
            Console.WriteLine("*********************************************");
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("*********************************************");
            Console.ReadKey();
            sw.Reset();

            sw.Start();
            for (int i = 0, j = 0; i < 2000; i++, j++)
                Console.WriteLine("{0}\t{1}", i.ToString(), j.ToString());

            sw.Stop();
            Console.WriteLine("*********************************************");
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("*********************************************");
            sw.Reset();

            Console.ReadKey();



            Console.ReadKey();
        }
    }
}
