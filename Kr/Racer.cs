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
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Starts = starts;
            this.Wins = wins;
            this.Years = new List<int>(years);
            this.Cars = new List<string>(cars);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public override string ToString()
        {
            return String.Format("{0} {1}, {2}; starts: {3}, wins: {4}",
            FirstName, LastName, Country, Starts, Wins);
        }
        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.LastName, other.LastName);
        }
    }
}
