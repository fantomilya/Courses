using System;

namespace Dz3
{
    public class Moderator : User
    {
        public Moderator() : base(() => Console.WriteLine("I can't add material"), 
                                    () => Console.WriteLine("I can't delete material"), 
                                    () => Console.WriteLine("I'm editing material"), 
                                    () => Console.WriteLine("I'm reading material"))
        {

        }
    }
}
