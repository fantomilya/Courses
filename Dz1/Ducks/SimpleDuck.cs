using System;

namespace Dz1.Ducks
{
    public class SimpleDuck:BaseDuck
    {
        public SimpleDuck()
        {
            Show = () => Console.WriteLine("I'm a simple duck");
        }
    }
}
