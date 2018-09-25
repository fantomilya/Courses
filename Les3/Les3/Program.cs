using System;
using System.Linq;
using Extensions;

namespace Les3
{
    internal class Program
    {
        private static void Showinfo() => Console.WriteLine("some info...");

        private static int Sum(int x1, int x2) => x1 + x2;

        private static int Fact(int k) => k > 1 ? k * Fact(k - 1) : 1;

        private static string AddSpaces(string s)
        {
            string res = string.Empty;
            for (var i = 0; i < s.Length; i++)
                res += (i + 1) % 4 == 0 ? s[i]+ " ": s[i].ToString();

            return res;
        }

        private static string BinaryToNegative(string s)
        {
            var result = s.Select(p => p == '0'? '1': '0').GetString("").TrimEnd('1');
            return result.Substring(0, result.Length - 1) + "1".PadRight(s.Length - result.Length + 1, '0');
        }

        private static string ToBinary(byte number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + number % 2;
            if (startBitNumber == 0)
                result = AddSpaces(result.PadLeft(sizeof(byte) * 8, '0'));

            return result;
        }

        private static string ToBinary(ushort number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + number % 2;
            if (startBitNumber == 0)
                result = AddSpaces(result.PadLeft(sizeof(short) * 8, '0'));

            return result;
        }

        private static string ToBinary(uint number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + number % 2;
            if (startBitNumber == 0)
                result = AddSpaces(result.PadLeft(sizeof(int) * 8, '0'));

            return result;
        }

        private static string ToBinary(ulong number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + number % 2;
            if (startBitNumber == 0)
                result = AddSpaces(result.PadLeft(sizeof(long) * 8, '0'));

            return result;
        }

        private static string ToBinary(sbyte number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + Math.Abs(number % 2);
            if (startBitNumber == 0)
            {
                result = result.PadLeft(sizeof(sbyte) * 8, '0');
                if (number < 0)
                    result = BinaryToNegative(result);
                result = AddSpaces(result);
            }

            return result;
        }

        private static string ToBinary(short number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result = ToBinary(number / 2, startBitNumber + 1) + Math.Abs(number % 2);
            if (startBitNumber == 0)
            {
                result = result.PadLeft(sizeof(short) * 8, '0');
                if (number < 0)
                    result = BinaryToNegative(result);
                result = AddSpaces(result);
            }

            return result;
        }

        private static string Convert1(int k) => k < 2 ? (k % 2).ToString() : Convert1(k / 2) + k % 2;

        private static string ToBinary(int number, int startBitNumber = 0)
        {
            if (number == 0)
                return "0";

            var result = ToBinary(number / 2, startBitNumber + 1) + Math.Abs(number % 2);
            if (startBitNumber == 0)
            {
                result = result.PadLeft(sizeof(int) * 8, '0');
                if (number < 0)
                    result = BinaryToNegative(result);
                result = AddSpaces(result);
            }

            return result;
        }

        private static string ToBinary(long number, int startBitNumber = 0)
        {
            if (number == 0)
                return string.Empty;

            var result =  ToBinary(number / 2, startBitNumber + 1) + Math.Abs(number % 2);
            if (startBitNumber == 0)
            {
                result = result.PadLeft(sizeof(long) * 8, '0');
                if (number < 0)
                    result = BinaryToNegative(result);
                result = AddSpaces(result);
            }
                
            return result;
        }

        private static void Main()
        {
            Console.WriteLine(Convert1(0));

            //for (uint i = uint.MinValue; i <= uint.MaxValue; i++)
            //    if (ToBinary(i).Replace(" ", "").TrimStart('0').DefaultIfEmpty('0').Select(p => p.ToString()).Combine() is var b1 && Convert.ToString(i, 2) is var b2 && b1 != b2)
            //        Console.WriteLine($"{i.GetType().Name} {i}\n   {b1}\n   !=\n   {b2}\n");
            
            int x = -5, y = 0;
            Console.WriteLine($"x={x} y={y} в " +
                              (x == 0 && y == 0? "0"
                                               : x >= 0? y >= 0 ? "I"
                                                                : "IV"
                                                       : y >= 0 ? "II"
                                                                : "III") 
                              + " четверти");
            Console.ReadKey();
        }
    }
}
