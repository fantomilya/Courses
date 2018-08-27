using System;

namespace Dz3
{
    public class Guest : User
    {
        public Guest() : base(() => Console.WriteLine("I can't add material"), 
                                    () => Console.WriteLine("I can't delete material"), 
                                    () => Console.WriteLine("I can't edit material"), 
                                    () => Console.WriteLine("I'm reading material"))
        {

        }
    }
}
