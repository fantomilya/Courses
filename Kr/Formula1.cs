﻿using System.Collections.Generic;

namespace Kr
{
    public static class Formula1
    {
        private static List<Racer> racers;
        public static IList<Racer> GetChampions()
        {
            return racers ?? (racers = new List<Racer>(40)
            {
                new Racer("Nino", "Farina", "Italy", 33, 5, new[] {1950}, new[] {"Alfa Romeo"}),
                new Racer("Alberto", "Ascari", "Italy", 32, 10, new[] {1952, 1953}, new[] {"Ferrari"}),
                new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new[] {1951, 1954, 1955, 1956, 1957},
                    new[] {"Alfa Romeo", "Maserati", "Mercedes", "Ferrari"}),
                new Racer("Mike", "Hawthorn", "UK", 45, 3, new[] {1958}, new[] {"Ferrari"}),
                new Racer("Phil", "Hill", "USA", 48, 3, new[] {1961}, new[] {"Ferrari"}),
                new Racer("John", "Surtees", "UK", 111, 6, new[] {1964}, new[] {"Ferrari"}),
                new Racer("Jim", "Clark", "UK", 72, 25, new[] {1963, 1965}, new[] {"Lotus"}),
                new Racer("Jack", "Brabham", "Australia", 125, 14, new[] {1959, 1960, 1966},
                    new[] {"Cooper", "Brabham"}),
                new Racer("Denny", "Hulme", "New Zealand", 112, 8, new[] {1967}, new[] {"Brabham"}),
                new Racer("Graham", "Hill", "UK", 176, 14, new[] {1962, 1968}, new[] {"BRM", "Lotus"}),
                new Racer("Jochen", "Rindt", "Austria", 60, 6, new[] {1970}, new[] {"Lotus"}),
                new Racer("Jackie", "Stewart", "UK", 99, 27, new[] {1969, 1971, 1973},
                    new[] {"Matra", "Tyrrell"})
            });
        }
        private static List<Team> teams;
        public static IList<Team> GetContructorChampions()
        {
            return teams ?? (teams = new List<Team>
            {
                new Team("Vanwall", 1958),
                new Team("Cooper", 1959, 1960),
                new Team("Ferrari", 1961, 1964, 1975, 1976, 1977, 1979, 1982,
                    1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008),
                new Team("BRM", 1962),
                new Team("Lotus", 1963, 1965, 1968, 1970, 1972, 1973, 1978),
                new Team("Brabham", 1966, 1967),
                new Team("Matra", 1969),
                new Team("Tyrrell", 1971),
                new Team("McLaren", 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998),
                new Team("Williams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996,
                    1997),
                new Team("Benetton", 1995),
                new Team("Renault", 2005, 2006),
                new Team("Brawn GP", 2009),
                new Team("Red Bull Racing", 2010, 2011)
            });
        }
    }
}
