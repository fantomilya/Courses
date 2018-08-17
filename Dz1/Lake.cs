using Dz1.Ducks;
using System;
using System.Collections.Generic;

namespace Dz1
{
    class Lake:List<BaseDuck>
    {
        public Lake()
        {
            AddRange(new BaseDuck[] { new SimpleDuck(), new ExoticDuck(), new SiliconDuck(), new WoodenDuck() });
        }
        public void Execute()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var d in this)
            {
                d.Show();
                d.Talk();
                d.Swim();
                d.Fly();
                Console.WriteLine();
            }
        }
        public void Kill(int index)
        {
            if (index > 0 && index < Count)
            {
                this[index].Fly = () => Console.WriteLine("I can't fly-------------------------------------");
                this[index].Talk = () => Console.WriteLine("I can't talk------------------------------------");
                this[index].Swim = () => Console.WriteLine("I can't swim------------------------------------");
            }
        }
    }
}
