using System;
using System.Collections;

namespace Les20
{
    public class Fish
    {
        //разобрать пример и поправить Equals
        private readonly string name;

        public Fish(string name) => this.name = name;

        public override int GetHashCode() => name.GetHashCode();

        public override bool Equals(object obj)
        {
            var otherFish = obj as Fish;

            if (otherFish == null)
                return false;

            return otherFish.name == name;
        }
    }

    class Program
    {
        static void Main()
        {
            var duplicates = new Hashtable();

            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");

            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";

            Console.WriteLine(duplicates.Count);

            Console.ReadKey();
        }
    }

}