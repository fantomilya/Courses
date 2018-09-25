using System;

namespace Les22
{
    delegate void MyDelegate(int argument);
    class Program
    {
        static void Main()
        {
            MyDelegate my = null;

            my = i =>
            {
                i--;
                Console.WriteLine("Begin {0}", i);

                if (i > 0)
                {
                    my(i);
                }

                Console.WriteLine("End {0}", i);
            };

            my(3);

            Console.ReadKey();
        }
    }


}