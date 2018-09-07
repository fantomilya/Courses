using System;

namespace Les9
{
    internal class Program
    {
        public static void WorldOfTanks(int n = 5)
        {
            Tank[] tanks1 = new Tank[n];
            Tank[] tanks2 = new Tank[n];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"Состав".PadRight(15)}{"Боекомплект".PadRight(15)}{"Уровень брони".PadRight(15)}{"Маневренность".PadRight(15)}");
            Console.WriteLine(new string('-', 60));

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < n; i++)
            {
                tanks1[i] = new Tank("T-34");
                tanks2[i] = new Tank("Pantera");
                Console.WriteLine($"Бой {i + 1} {new string('-', 56 - (i+1).ToString().Length)}\n{tanks1[i]}\n{tanks2[i]}");
            }
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Бой {(i+1).ToString().PadRight(n.ToString().Length)} {tanks1[i].Name}*{tanks2[i].Name} ");
                int res = tanks1[i] * tanks2[i];
                counter += res;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{(res == 1 ? "Победа " + tanks1[i].Name : res == -1 ? "Победа " + tanks2[i].Name : "Ничья")}");
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{(counter > 0 ? "Победа T-34" : counter < 0 ? "Победа Pantera" : "Ничья")}");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        private static void Main()
        {
            WorldOfTanks(10);
            Random r = new Random();
            int count = 5000;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    int day = r.Next(1, 31);
                    int month = r.Next(1, 12);
                    int year = r.Next(1900, 3000);

                    Date date1 = new Date(year, month, day);
                    DateTime dateTime1 = new DateTime(year, month, day);

                    int days = r.Next(-10000, 10000);
                    var dateTimeAdded = dateTime1.AddDays(days);
                    var dateAdded = date1 + days;
                    if (dateAdded.Year != dateTimeAdded.Year || dateAdded.Month != dateTimeAdded.Month || dateAdded.Day != dateTimeAdded.Day)
                        Console.WriteLine($"{i.ToString().PadRight(3)}Неверное добавление {dateTime1.ToString("dd-MM-yyyy")} + {days} = {dateAdded} вместо {dateTimeAdded.ToString("dd-MM-yyyy")}");

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    day = r.Next(1, 31);
                    month = r.Next(1, 12);
                    year = r.Next(1900, 3000);
                    Date date2 = new Date(year, month, day);
                    DateTime dateTime2 = new DateTime(year, month, day);

                    int resDateTime = (dateTime1 - dateTime2).Days;
                    int resDate = date1 - date2;
                    if (resDateTime != resDate)
                        Console.WriteLine($"{i.ToString().PadRight(3)}Неверное отнимание {date1} - {date2} = {resDate} вместо {resDateTime}");
                }
                catch
                {

                }
            }
            Console.WriteLine($"Done {count}");
            Console.ReadKey(true);
        }
    }
}