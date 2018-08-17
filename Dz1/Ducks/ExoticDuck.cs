using System;

namespace Dz1.Ducks
{
    public class ExoticDuck : BaseDuck
    {
        public ExoticDuck()
        {
            Show = () => Console.WriteLine("I'm an exotic duck");
        }
    }
}
