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
        public int Compare(Person x, Person y) => x.LastName.CompareTo(y.LastName) is var i && i != 0 ? i : x.FirstName.CompareTo(y.FirstName);
    }

}
