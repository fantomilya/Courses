using Dz1.Ducks;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz1
{
    internal class Lake:List<BaseDuck>
    {
        public Lake()
        {
            AddRange(new BaseDuck[] { new SimpleDuck(), new ExoticDuck(), new SiliconDuck(), new WoodenDuck() });
        }

        private void Show()
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
        public void Execute()
        {
            Show();
            this.FirstOrDefault().Talk = () => Console.WriteLine("I'm talking cool!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Show();
            Kill(3);
            Show();
        }
        public void Kill(int index)
        {
            if (index.Between(0, Count, false, false))
            {
                this[index].Fly = () => Console.WriteLine("I can't fly-------------------------------------");
                this[index].Talk = () => Console.WriteLine("I can't talk------------------------------------");
                this[index].Swim = () => Console.WriteLine("I can't swim------------------------------------");
            }
        }
    }
}
