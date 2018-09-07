using Extensions;
using System;
using System.Linq;

namespace Les4
{
    internal class Program
    {
        public static void Resize<T>(ref T[] sourceArray, int newSize)
        {
            T[] res = new T[newSize];
            Array.Copy(sourceArray, res, Math.Min(sourceArray.Length, newSize));
            sourceArray = res;
        }
        public static void Zadanie1()
        {
            var rand = new Random();
            int[] arr = new int[5];//ConsoleGetNumberInt("Размер массива = ", "Неверное значение")];
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write((arr[i] = rand.Next(-99, 99)) + " ");

            Resize(ref arr, 2);

            Console.Write($"\nНаибольшее значение = {arr.Max()}\n" +
                            $"Наименьшее значение = {arr.Min()}\n" +
                            $"Общая сумма = {arr.Sum()}\n" +
                            $"Среднее арифметическое = {arr.Average():##.##}\n\n" +
                            "Нечетные значения: ");

            foreach (var v in arr.Where(p => p % 2 != 0))
                Console.Write(v + " ");

            Console.WriteLine();
            Console.ReadKey();
        }
        public static int[] SubArray(int[] array, int index, int count)
        {
            var resArr = new int[count];
            for (int i = index; i < index + count; i++)
                resArr[i - index] = i > array.Length - 1 ? 1 : array[i];
            return resArr;
        }
        public static void MatrixMultiplication()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nПомните, что количество столбцов первой матрицы\nдолжно совпадать с количеством строк второй матрицы!\n");
            Console.ResetColor();

            var r1 = ConsoleGetNumberInt("Введите количество строк первой матрицы a:");
            var c1 = ConsoleGetNumberInt("Введите количество столбцов первой матрицы a:");
            var r2 = ConsoleGetNumberInt("Введите количество строк второй матрицы b:", condition: p => p == c1, conditionErrorMessage: "Не совпадает количество столбцов первой матрицы и количество строк второй матрицы");
            var c2 = ConsoleGetNumberInt("Введите количество столбцов второй матрицы b:");

            var m1 = new int[r1, c1];
            var m2 = new int[r2, c2];
            var res = new int[r1, c2];
            m1.FillRand(0, 9);
            m2.FillRand(0, 9);
            Console.WriteLine("\nПервая матрица\n" + m1.AsString());
            Console.WriteLine("Вторая матрица\n" + m2.AsString());
            for (int i = 0; i < r1; i++)
                for (int j = 0; j < c2; j++)
                    for (int k = 0; k < c1; k++)
                        res[i, j] += m1[i, k] * m2[k, j];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Результирующая матрица");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(res.AsString());
            Console.ReadKey(true);
        }
        public static void Calculator()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nMainMenu\n\nSelect operation:\n\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Power\n6. Factorial\n7. Clear Screen\n\n8. Exit\n");
                Console.ResetColor();

                int op = ConsoleGetNumberInt("Enter the number of selected operation: ", "Invalid operation",
                    p => p.Between(0, 9, false, false));

                double k1 = 0, k2 = 0;
                if (op < 7)
                {
                    k1 = ConsoleGetNumberDouble("Enter the first value: ");
                    if (op < 6)
                        k2 = ConsoleGetNumberDouble("Enter the second value: ");

                    Console.Write("Result is ");
                }

                switch (op)
                {
                    case 1:
                        Console.WriteLine(k1 + k2);
                        break;
                    case 2:
                        Console.WriteLine(k1 - k2);
                        break;
                    case 3:
                        Console.WriteLine(k1 * k2);
                        break;
                    case 4:
                        Console.WriteLine(k2 == 0? "infinity": (k1 / k2).ToString("##.##"));
                        break;
                    case 5:
                        Console.WriteLine(Math.Pow(k1, k2));
                        break;
                    case 6:
                        Console.WriteLine(Fact((int)k1));
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    case 8:
                        Console.WriteLine(@"Do you want to exit? yes\no");
                        if (Console.ReadLine() == "yes")
                            return;
                        break;
                }
            }
        }

        private static void Main()
        {
            Zadanie1();
            var subArray = SubArray(new[] { 1, 2, 3, 4 }, 1, 4);
            var reverse = MyReverse(subArray);
            MatrixMultiplication();
            Calculator();
            Console.ReadKey();
        }
        public static int ConsoleGetNumberInt(string message = "Введите число: ", string errorMessage = "Вводимое значение должно быть числового формата", Func<int, bool> condition = null, string conditionErrorMessage = null)
        {
            Console.Write(message);
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;

            int res;
            condition = condition ?? (p => true);
            conditionErrorMessage = conditionErrorMessage ?? errorMessage;
            while (int.TryParse(Console.ReadLine(), out res) is bool isParsed && (!isParsed || !condition(res)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(isParsed ? conditionErrorMessage : errorMessage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Press any key\n");
                Console.ResetColor();
                Console.ReadKey(true);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                ConsoleClear(5);
            }

            return res;
        }
        public static double ConsoleGetNumberDouble(string message = "Введите число: ", string errorMessage = "Вводимое значение должно быть числового формата", Func<double, bool> condition = null, string conditionErrorMessage = null)
        {
            Console.Write(message);
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            condition = condition ?? (p => true);
            conditionErrorMessage = conditionErrorMessage ?? errorMessage;

            double res;
            while (double.TryParse(Console.ReadLine(), out res) is bool isParsed && (!isParsed || !condition(res)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(isParsed ? conditionErrorMessage : errorMessage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Press any key\n");
                Console.ResetColor();
                Console.ReadKey(true);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                ConsoleClear(5);
            }

            return res;
        }

        private static int Fact(int k) => k > 1 ? k * Fact(k - 1) : 1;
        public static int[] MyReverse(int[] array)
        {
            int[] res = new int[array.Length];
            for (int i = 0; i < array.Length / 2; i++)
            {
                res[i] = array[array.Length - i - 1];
                res[array.Length - i - 1] = array[i];
            }

            return res;
        }

        private static void ConsoleClear(int rowsCount, int? leftFrom = null, int? topFrom = null)
        {
            var leftSaved = Console.CursorLeft;
            var topSaved = Console.CursorTop;
            int leftFrom1 = leftFrom ?? leftSaved;
            int topFrom1 = topFrom ?? topSaved;
            var isNeedShift = topSaved > topFrom || topSaved == topFrom && leftSaved > leftFrom;
            if (isNeedShift)//toDo
                topSaved -= rowsCount;

            Console.SetCursorPosition(leftFrom1, topFrom1);
            Console.Write(new string(' ', rowsCount * Console.WindowWidth - leftFrom1));

            Console.SetCursorPosition(leftSaved, topSaved);
        }


    }
}