using System;
using System.Collections;

internal class Program
{
    private class UserCollection
    {
        public static IEnumerable Power()
        {
            yield return "Hello world!";
            yield return "Hello world!";
            yield return "Hello world!";
            yield return "Hello world!";
        }
    }

    private static void Main()
    {
        foreach (string element in UserCollection.Power())
            Console.WriteLine(element);

        Console.WriteLine(new string('-', 12));

        //----------------------
        // Так работает foreach.

        IEnumerable enumerable = UserCollection.Power();

        IEnumerator enumerator = enumerable.GetEnumerator();

        while (enumerator.MoveNext())
        {
            String element = enumerator.Current as String;

            Console.WriteLine(element);
        }

        Console.ReadKey();
    }

}

