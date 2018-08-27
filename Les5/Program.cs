using System;

namespace Les5
{
    class Program
    {
        static void Main()
        {
            string str1 = "Я ";
            string str2 = "учу ";
            string str3 = "C#";
            string str4 = str1 + str2 + str3;

            Console.WriteLine("{0} + {1} + {2} = {3}", str1, str2, str3, str4);

            str4 = str4.Replace("учу", "изучаю");
            Console.WriteLine(str4);

            str4 = str4.Insert(2, "упорно ").ToUpper();
            Console.WriteLine(str4);

            if (str4.Contains("упорно"))
                Console.WriteLine("Учу таки упорно :)");
            else
                Console.WriteLine("Учу как могу");

            str4 = str4.PadLeft(25, '*');
            str4 = str4.PadRight(32, '*');
            Console.WriteLine(str4);
            str4 = str4.TrimStart("*".ToCharArray());
            Console.WriteLine(str4);
            str4 = str4.TrimEnd("*".ToCharArray());
            Console.WriteLine(str4);
            string[] strArr = str4.Split(" ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArr)
                Console.WriteLine(str);
            str4 = str4.Remove(9);
            str4 += "учусь";
            Console.WriteLine(str4);

            Console.ReadLine();
        }


    }
}
