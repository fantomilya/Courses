using System;
using System.Linq;

namespace Extensions
{
    public static class RandomExtensions
    {
        public static bool NextBool(this Random rand, int percentChanse = 50) => rand.Next(100) < percentChanse;

        public static T OneOf<T>(this Random rand, params T[] items) => items?.Any() != true ? default(T) : items[rand.Next(items.Length)];

        public static DateTime NextDate(this Random rand, DateTime minDate, DateTime maxDate) => minDate.AddDays(rand.Next((int)(maxDate - minDate).TotalDays));
    }
}
