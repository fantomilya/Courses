using System;
using System.Linq;

namespace Extensions
{
    public static class RandomExtensions
    {
        public static bool NextBool(this Random rand, int percentChanse = 50) => rand.Next(99) < percentChanse;

        public static T OneOf<T>(this Random rand, params T[] items) => items?.Any() != true ? default(T) : items[rand.Next(items.Length)];
    }
}
