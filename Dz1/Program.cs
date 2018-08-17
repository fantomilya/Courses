using System;
using System.Linq;

namespace Dz1
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new Lake();
            l.Execute();
            l.FirstOrDefault().Talk = () => Console.WriteLine("I'm talking cool!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            l.Execute();
            l.Kill(3);
            l.Execute();
            Console.ReadKey(true);
        }
    }
}
