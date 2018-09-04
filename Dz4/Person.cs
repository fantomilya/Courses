using System.Collections.Generic;

namespace Dz4
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
    class PersonComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2) => p1.LastName.CompareTo(p2.LastName) is var i && i != 0 ? i : p1.FirstName.CompareTo(p2.FirstName);
    }
}
