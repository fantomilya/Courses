using System;

namespace Dz1.Ducks
{
    public class SiliconDuck : BaseDuck
    {
        public SiliconDuck():base(() => Console.WriteLine("I'm talking"), () => Console.WriteLine("I can't fly"), () => Console.WriteLine("I'm swiming"))
        {
            Show = () => Console.WriteLine("I'm a silicon duck");
        }
    }
}
