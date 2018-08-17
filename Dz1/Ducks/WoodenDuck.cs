using System;

namespace Dz1.Ducks
{
    public class WoodenDuck : BaseDuck
    {
        public WoodenDuck() : base(() => Console.WriteLine("I can't talk"), () => Console.WriteLine("I can't fly"), () => Console.WriteLine("I'm swiming"))
        {
            Show = () => Console.WriteLine("I'm a wooden duck");
        }
    }
}
