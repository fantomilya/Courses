using System;

namespace Dz3
{
    public class Administrator : User
    {
        public Administrator() : base(() => Console.WriteLine("I'm adding material"), 
                                        () => Console.WriteLine("I'm deleting material"), 
                                        () => Console.WriteLine("I'm editing material"), 
                                        () => Console.WriteLine("I'm reading material"))
        {

        }
    }
}
