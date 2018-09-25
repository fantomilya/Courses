using System;
using System.IO;

namespace Les21
{
    class Program
    {
        static void Main()
        {
            FileStream file = File.Open(@"E:\test.txt", FileMode.Open);

            BinaryReader reader = new BinaryReader(file);

            string s = reader.ReadString();
            byte[] bytes = reader.ReadBytes(4);
            long number = reader.ReadInt64();

            reader.Close();

            Console.WriteLine(number);
            foreach (byte b in bytes)
            {
                Console.Write("[{0}]", b);
            }

            Console.WriteLine();
            Console.WriteLine(s);

            Console.ReadKey();
        }

    }
}

