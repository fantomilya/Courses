using System;
using System.Linq;

namespace Les6
{
    internal enum Diraction
    {
        Left,
        Down,
        Right,
        Up
    }

    internal class Program
    {
        public static Random rand = new Random();
        public static void Task1()
        {
            /*
             Дано значение температуры T в градусах Фаренгейта. Определить значение этой же температуры в градусах Цельсия.
             */
            double tF = rand.NextDouble() * 100;
            Console.WriteLine($"Температура {tF:##.##} по Фаренгейту = {(tF - 32) * 5 / 9:##.##} по Цельсию");
        }
        public static void Task2()
        {
            /*
            Для нахождения площади треугольника со сторонами a, b, c использовать формулу Герона: 
            S = (p•(p – a)•(p – b)•(p – c))1/2,
            где p = (a + b + c)/2 — полупериметр.
             */
            int x1 = rand.Next(-100, 100);
            int x2 = rand.Next(-100, 100);
            int x3 = rand.Next(-100, 100);
            int y1 = rand.Next(-100, 100);
            int y2 = rand.Next(-100, 100);
            int y3 = rand.Next(-100, 100);
            double D(int xx1, int yy1, int xx2, int yy2) => Math.Sqrt((xx2 - xx1) * (xx2 - xx1) - (yy2 - yy1) * (yy2 - yy1));
            double d1 = D(x1, x2, y1, y2);
            double d2 = D(x1, x3, y1, y3);
            double d3 = D(x3, x2, y3, y2);
            double p = (d1 + d2 + d3) / 2;
            double s = Math.Sqrt(p * (p - d1) * (p - d1) * (p - d3));
            Console.WriteLine($"Координаты вершин треугольника ({x1}, {y1}), ({x2}, {y2}) ({x3}, {y3})\n Периметр {p * 2:##.##}\n Площадь {s:##.##}");
        }
        public static void Task3()
        {
            /*
             Ввести с клавиатуры номер трамвайного билета (6-значное число) и 
             проверить является ли данный билет счастливым 
             (если на билете напечатано шестизначное число, и сумма первых трёх цифр равна сумме последних трёх, 
             то этот билет считается счастливым).
             */
            string s;
            while (!int.TryParse(s = Console.ReadLine(), out _) || s.Length != 6)
                Console.WriteLine("Неверное значение");

            Console.WriteLine($"Билет {s} - {(s.Substring(0, 3).Sum(p => int.Parse(p.ToString())) == s.Substring(s.Length - 3).Sum(p => int.Parse(p.ToString())) ? "счастливый" : "не счастливый")}");
        }
        public static void Task4()
        {
            /*
             Числовые значения символов нижнего регистра в коде ASCII отличаются от значений символов верхнего регистра на величину 32. 
             Используя эту  информацию, написать программу, которая считывает с клавиатуры и конвертирует все символы нижнего регистра в символы верхнего регистра и наоборот.
             */
            string s;
            while ((s = Console.ReadLine()).Any(p => !char.IsLetter(p)))
                Console.WriteLine("строка содержит не только буквы");

            Console.WriteLine("\n" + new string(s.Select(p => (char)(char.IsUpper(p) ? p + 32 : p - 32)).ToArray()));
        }
        public static void Task5()
        {
            /*
             Дано целое число в диапазоне 100–999. Вывести строку-описание данного числа, например: 256 — «двести пятьдесят шесть», 814 — «восемьсот четырнадцать».
             */
            int k = rand.Next(100, 999);
            string s = string.Empty;
            var n1 = k % 10;
            var n2 = k / 10 % 10;
            var n3 = k / 100;
            if (n2 == 1)
            {
                if (n1 == 1)
                    s = "одиннадцать";
                else if (n1 == 2)
                    s = "двенадцать";
                else if (n1 == 3)
                    s = "тринадцать";
                else if (n1 == 4)
                    s = "четырнадцать";
                else if (n1 == 5)
                    s = "пятнадцать";
                else if (n1 == 6)
                    s = "шестнадцать";
                else if (n1 == 7)
                    s = "семнадцать";
                else if (n1 == 8)
                    s = "восемнадцать";
                else if (n1 == 9)
                    s = "девятнадцать";
            }
            else
            {
                if (n1 == 1)
                    s = "один";
                else if (n1 == 2)
                    s = "два";
                else if (n1 == 3)
                    s = "три";
                else if (n1 == 4)
                    s = "четыре";
                else if (n1 == 5)
                    s = "пять";
                else if (n1 == 6)
                    s = "шесть";
                else if (n1 == 7)
                    s = "семь";
                else if (n1 == 8)
                    s = "восемь";
                else if (n1 == 9)
                    s = "девять";

                if (n2 == 2)
                    s = "двадцать" + s;
                else if (n2 == 3)
                    s = "тридцать" + s;
                else if (n2 == 4)
                    s = "сорок" + s;
                else if (n2 == 5)
                    s = "пятьдесят" + s;
                else if (n2 == 6)
                    s = "шестьдесят" + s;
                else if (n2 == 7)
                    s = "семьдесят" + s;
                else if (n2 == 8)
                    s = "восемьдесят" + s;
                else if (n2 == 9)
                    s = "девяносто" + s;
            }

            if (n3 == 1)
                s = "сто";
            else if (n3 == 2)
                s = "двести" + s;
            else if (n3 == 3)
                s = "триста" + s;
            else if (n3 == 4)
                s = "четыреста" + s;
            else if (n3 == 5)
                s = "пятьсот" + s;
            else if (n3 == 6)
                s = "шестьсот" + s;
            else if (n3 == 7)
                s = "семьсот" + s;
            else if (n3 == 8)
                s = "восемьсот" + s;
            else if (n3 == 9)
                s = "девятьсот" + s;

            Console.WriteLine(k + " - " + s);
        }
        public static void Task6()
        {   
            /*
             Даны целые положительные числа A, B, C. Значение этих чисел программа должна запрашивать у пользователя. 
             На прямоугольнике размера A*B размещено максимально   возможное   количество   квадратов   со стороной C. 
             Квадраты не накладываются друг на друга. Найти количество квадратов, размещенных на прямоугольнике, 
             а также площадь незанятой части прямоугольника. Необходимо предусмотреть служебные сообщения в случае, 
             если в прямоугольнике нельзя разместить ни одного квадрата со стороной С.
             */
            int a = rand.Next(0, 100);
            int b = rand.Next(0, 100);
            int c = rand.Next(0, 100);

            int inRow = a / c;
            int inColumn = b / c;
            int count = inRow * inColumn;
            Console.WriteLine(
                $"В прямоугольнике с размерами {a} на {b} {(count == 0 ? "нельзя разместить ни одного квадрата" : "можно разместить " + count + "кв.")} со стороной {c}"
                + $"\nОставшаяся площадь {a * b - c * c * count}");
        }
        public static void Task7()
        {
            /*
             Начальный вклад в банке равен 1000 руб. Через каждый месяц размер вклада увеличивается на P процентов от имеющейся суммы. 
             По данному P определить, через сколько месяцев размер вклада превысит 1100 руб., и вывести найденное количество месяцев K и итоговый размер вклада 
             S (Итоговый размер вклада вывести максимально точно).
             */
            decimal n = 1000;
            int p = rand.Next(1, 10);
            int count = 0;
            while (n <= 1100)
            {
                n += n * p / 100;
                count++;
            }

            Console.WriteLine($"При ежемесячной ставке в {p}% вклад достигнет размера {n} (> 1100) через {count} мес.");
        }
        public static void Task8()
        {
            /*
             Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка. 
             Программа должна сосчитать количество введенных пользователем пробелов. 
             */
            int count = 0;
            while (Console.ReadKey() is var c && c.KeyChar != '.')
                if (c.KeyChar == ' ')
                    count++;

            Console.WriteLine($".\nВведено {count} пробелов");
        }
        public static void Task9()
        {   /*
             Даны целые положительные числа A и B (A<B). Вывести все целые числа от A до B  включительно; 
             каждое число должно выводиться на новой строке; при этом каждое  число должно выводиться количество раз, равное его значению. 
             Например: если А = 3, а В =  7, то программа должна сформировать в консоли следующий вывод:
             */
            int a = rand.Next(0, Console.WindowWidth);
            int b = rand.Next(0, Console.WindowWidth);
            if (a > b)
                Switch(ref a, ref b);

            for (int n = a; n <= b; n++)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(n);

                Console.WriteLine();
            }
        }
        public static void Task10()
        {
            /*
             Дано целое число N (> 0), найти число, полученное при прочтении числа N справа налево. 
             Например, если было введено число 345,  то  программа должна вывести число 543.
             */
            int n = rand.Next(0, 100);
            string s = new string(n.ToString().Reverse().ToArray()).TrimStart('0');
            Console.Write($"Число {n}; перевернутое {(s == string.Empty ? "0" : s)}");
        }
        public static void Task11()
        {
            /*
             Пользователь вводит текст, строку для поиска и строку для замены. Реализовать поиск в тексте заданной строки и замены ее на заданную подстроку. 
             */
            Console.Write("Строка: ");
            string str = Console.ReadLine();
            Console.Write("Подстрока: ");
            string subStr = Console.ReadLine();
            Console.Write("Строка для замены: ");
            string replaceStr = Console.ReadLine();
            Console.Write("Результат: " + str.Replace(subStr, replaceStr));
        }
        public static void Task12()
        {
            /*
             Пользователь вводит строку. Проверить, является ли эта строка палиндромом. 
             Палиндромом называется строка, которая одинаково читается слева направо и справа налево.
             */
            string s = Console.ReadLine();
            bool isPalindrom = true;
            int l = s.Length / 2;
            for (int i = 0; i < l; i++)
                if (s[i] != s[s.Length - i - 1])
                {
                    isPalindrom = false;
                    break;
                }

            Console.WriteLine($"Строка \"{s}\" - {(isPalindrom ? "палиндром" : "не палиндром")}");
        }
        public static void Task13()
        {
            /*
             Подсчитать количество слов во введенном предложении. Решить двумя способами.
             */
            string s = Console.ReadLine();
            int currentChar = s.Length - 1;
            int count = 0;
            while (currentChar > 0)
            {
                bool exists = false;
                while (char.IsLetterOrDigit(s[currentChar]) && currentChar > 0)
                {
                    currentChar--;
                    exists = true;
                }

                if (exists)
                    count++;

                while (!char.IsLetterOrDigit(s[currentChar]) && currentChar > 0)
                    currentChar--;
            }

            var splitChars = Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue).Select(p => (char)p).Where(p => !char.IsLetterOrDigit(p)).ToArray();
            int count1 = s.Split(splitChars, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"В строке \"{s}\" {count}/{count1} слов");
        }
        public static void Task14()
        {
            /*
             Пользователь вводит русский текст. Подсчитать количество слов, которые заканчиваются на гласную букву.
             */
            char[] vowelLetters = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            string s = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
                if (vowelLetters.Contains(s[i]) && (i == s.Length - 1 || !char.IsLetterOrDigit(s[i + 1])))
                {
                    i++;
                    count++;
                }

            Console.WriteLine($"В строке \"{s}\" {count} слов, которые заканчиваются на гласные.");
        }
        public static void Task15()
        {
            /*
             Дан двумерный массив размерностью 5х5, заполненный случайными числами из диапазона от -100 до 100. 
             Определить сумму элементов массива, расположенных между минимальным и максимальным элементами.
             */
            int rows = 5;
            int columns = 5;
            var arr = new int[rows, columns];
            int iMax = 0, jMax = 0, iMin = 0, jMin = 0, max = -100, min = 100;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                    Console.Write(arr[i, j].ToString().PadLeft(4, ' '));
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        iMax = i;
                        jMax = j;
                    }

                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        iMin = i;
                        jMin = j;
                    }
                }
                Console.WriteLine();
            }

            int sum = 0;
            if (iMax < iMin || iMax == iMin && jMax < jMin)
            {
                Switch(ref jMax, ref jMin);
                Switch(ref iMax, ref iMin);
            }

            while (iMin < iMax || iMin == iMax && jMin <= jMax)
            {
                sum += arr[iMin, jMin++];
                if (jMin == arr.GetLength(1))
                {
                    jMin = 0;
                    iMin++;
                }
            }

            Console.WriteLine($"Сумма элементов между минимальным и максимальным элементами({min}, {max}) равна {sum}.");
        }
        public static void Task16()
        {
            /*
             Дан двумерный массив размерностью 5х5, заполненный случайными числами из диапазона от 0 до 100. Найти максимальные элементы каждого столбца.
            */
            int rows = 5;
            int columns = 5;
            var arr = new int[rows, columns];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(0, 100);
                    Console.Write(arr[i, j].ToString().PadLeft(3, ' '));
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int max = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    if (arr[i, j] > max)
                        max = arr[i, j];

                Console.Write(max.ToString().PadLeft(3, ' '));
            }
        }
        public static void Task17()
        {
            int rows = rand.Next(1, 20) / 2 + 1;
            int columns = rand.Next(1, 20) / 2 + 1;
            int[,] arr = new int[rows, columns];

            int i = rows / 2;
            int j = columns / 2;
            int center_i = i;
            int center_j = j;
            var curr_dir = new Diraction();
            while (i > 0 && j > 0 && i < arr.GetLength(0) && j < arr.GetLength(1))
            {

                curr_dir++;
                if ((int) curr_dir > 3) curr_dir = 0;

            }
            //2-мерн масс, не неч по всем измерениям. Заполнить улиткой с середины.
            throw new NotImplementedException();
        }

        private static void Main()
        {
            Task17();
            Console.ReadKey(true);
        }
        public static void Switch<T>(ref T first, ref T second)
        {
            T tmp = first;
            first = second;
            second = tmp;
        }
    }
}
