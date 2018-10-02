using System;
using System.Collections.Generic;

namespace Kr
{
    public class Racer : IComparable<Racer>
    {
        public Racer(string firstName, string lastName, string country,
        int starts, int wins)
        : this(firstName, lastName, country, starts, wins, null, null)
        {
        }
        public Racer(string firstName, string lastName, string country,
        int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Starts = starts;
            Wins = wins;
            Years = new List<int>(years);
            Cars = new List<string>(cars);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public override string ToString() => $"{FirstName} {LastName}, {Country}; starts: {Starts}, wins: {Wins}";

        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(LastName, other.LastName);
        }
    }
}
