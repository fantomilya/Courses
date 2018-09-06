using Extensions;
using System;
using System.Linq;

namespace Les1
{
    class Program
    {
        static void Main()
        {
            #region task1 ver1
#if !DEBUG
                var k1 = double.Parse(Console.ReadLine());
                var k2 = double.Parse(Console.ReadLine());
                var k3 = double.Parse(Console.ReadLine());
                Console.WriteLine(((k1 + k2 + k3) / 3).ToString("#.##") + '\n');
#endif
            #endregion

            #region task1 ver2
#if !DEBUG
            if (double.TryParse(Console.ReadLine(), out var n1) 
                && double.TryParse(Console.ReadLine(), out var n2) 
                && double.TryParse(Console.ReadLine(), out var n3))
                Console.WriteLine(((n1 + n2 + n3) / 3).ToString("#.##") + '\n');
#endif
            #endregion

            //const int count = 3;
            //Console.WriteLine("Среднее арифметическое = " + (Enumerable.Range(0, count).Select((p, i) => ReadDouble($"{i + 1}-е число = ")).Sum() / count).ToString("#.##") + '\n');
            //Console.ReadKey(true);

            //double r = ReadDouble("R = ");
            //double h = ReadDouble("H = ");
            //Console.WriteLine($"V = {Math.PI * r * r * h:#.##}");
            //Console.WriteLine($"S = {2 * Math.PI * r * (r + h):#.##}\n");
            //Console.ReadKey(true);
            Console.WriteLine("Задание 1");
            switch (ReadDouble("Введите число = "))
            {
                case double d when d.Between(0, 15, includeRight:false):
                    Console.WriteLine("От 0 до 14");
                    break;
                case double d when d.Between(15, 36, includeRight: false):
                    Console.WriteLine("От 15 до 35");
                    break;
                case double d when d.Between(36, 50, includeRight: false):
                    Console.WriteLine("От 36 до 50");
                    break;
                case double d when d == 50:
                    Console.WriteLine("От 36 до 50 и от 50 до 100");
                    break;
                case double d when d.Between(50, 101, false, false):
                    Console.WriteLine("От 50 до 100");
                    break;
                default:
                    Console.WriteLine("Не входит ни в один диапазон");
                    break;
            }
            Console.ReadKey(true);
            Console.WriteLine("\nЗадание 2");

            if (ReadInt("Число = ") is int v1)
            {
                Console.WriteLine(v1 % 2 == 0 ? "четное" : "нечетное");
                Console.WriteLine((v1 & 1) == 0 ? "четное" : "нечетное");
            }

            Console.ReadKey(true);
            Console.WriteLine("\nЗадание 2");

            int a = ReadInt("Промежуток от ");
            int b = ReadInt("Промежуток до ");

            if (b > 0 && b - a > 1)
            {
                Console.WriteLine("Сумма чисел в промежутке: " + Enumerable.Range(a + 1, b - a - 1).DefaultIfEmpty().Sum());
                Console.WriteLine("Нечетные числа в промежутке: " + Enumerable.Range(a + 1, b - a - 1).Where(p => p % 2 == 1).GetString() + '\n');
            }

            Console.ReadKey(true);
            Console.WriteLine("\nЗадание 3");

            try
            {
                ulong fact = 1;
                int count = ReadInt("Введите число = ");
                for (uint i = 1; i <= count; i++)
                    fact *= i;

                Console.WriteLine($"{count}! = {fact}");
                Console.WriteLine($"{count}! = {Enumerable.Range(1, count).Select(p => (ulong)p).Aggregate((p1, p2) => p1 * p2)}");

            }
            catch
            {
                Console.WriteLine("Не удалось посчитать.");
            }

            Console.ReadKey(true);
            Console.WriteLine("\nЗадание 4");

            int first = ReadInt("Первое число = ");
            Console.Write("Оператор ");
            string op = Console.ReadLine();
            int second = ReadInt("Второе число = ");

            switch (op)
            {
                case "+":
                    Sum(first, second);
                    break;
                case "-":
                    Sub(first, second);
                    break;
                case "*":
                    Mult(first, second);
                    break;
                case "/":
                    Div(first, second);
                    break;
                default:
                    Console.WriteLine("Неверный оператор");
                    break;
            }

            Console.ReadKey(true);
            Console.WriteLine("\nЗадание 5");

            if (!IsPositive(5L))
                throw new Exception();
            if (IsPositive(-1L))
                throw new Exception();
            if (!IsPositive(0L))
                throw new Exception();

            if (IsPrime(4))
                throw new Exception();
            if (IsPrime(27))
                throw new Exception();
            if (IsPrime(81))
                throw new Exception();
            if (!IsPrime(113))
                throw new Exception();
            if (!IsPrime(73))
                throw new Exception();

            var loginSaved = "someLogin";
            var passwordSaved = "somePassword";

            if (Console.ReadLine() != loginSaved)
                Console.WriteLine("неверный логин!");
            else if (Console.ReadLine() != passwordSaved)
                Console.WriteLine("неверный пароль!");
            int k = 5;
            switch (k)
            {
                case 5:
                case 6:
                    Console.WriteLine("a");
                    break;
            }
        }

        static void Sum(long first, long second) => Console.WriteLine($"{first} + {second} = {first + second}");
        static void Sub(long first, long second) => Console.WriteLine($"{first} - {second} = {first - second}");
        static void Mult(long first, long second) => Console.WriteLine($"{first} * {second} = {first * second}");
        static void Div(long first, long second) => Console.WriteLine(second == 0? "Попытка деления на ноль.": $"{first} / {second} = {first / second:#.##}");

        static bool IsPositive(IComparable<long> l) => l.CompareTo(0) >= 0;

        static bool IsPrime(long l)
        {
            for (long i = 2; i <=l / 2; i++)
                if (l % i == 0)
                    return false;

            return true;
        }
   
        /// <summary>
        /// Проверяет делится ли число нацело на все указанные делители.
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <param name="dividers">делители (по умолчанию 2, 5, 3, 6, 9)</param>
        /// <returns></returns>
        static bool IsDividesBy(long number, long[] dividers = null) =>
            (dividers ?? new[] {2L, 5L, 3L, 6L, 9L}).All(p => number % p == 0);

        static double ReadDouble(string preMessage = null, string postMessage = null)
        {
            if (!string.IsNullOrEmpty(preMessage))
                Console.Write(preMessage);

            double val = 0;
            while (Console.ReadLine()?.Replace(".", ",") is var valStr && !double.TryParse(valStr, out val))
                Console.Write($"Не удалось преобразовать \"{valStr}\" в число. Повторите ввод.\n\n{preMessage ?? string.Empty}");

            Console.Write(postMessage?? string.Empty);
            return val;
        }

        static int ReadInt(string preMessage = null, string postMessage = null) => (int)ReadDouble(preMessage, postMessage);
    }
}