using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Monthes : IEnumerable<Month>
    {
        Month[] MonthesArray { get; }

        public Monthes() : this(DateTime.Today.Year) { }
        public Monthes(int year)
        {
            MonthesArray = new Month[12];
            for (int i = 1; i < 13; i++)
                MonthesArray[i - 1] = new Month((MonthName)i, DateTime.DaysInMonth(year, i));
        }

        public Month this[int index] => index > 0 && index < 13 ? MonthesArray[index - 1] : default(Month);
        IEnumerator IEnumerable.GetEnumerator() => MonthesArray.GetEnumerator();
        public IEnumerator<Month> GetEnumerator()
        {
            foreach (var v in MonthesArray)
                yield return v;
        }
        public IEnumerable<Month> GetMonthesByDaysCount(int daysCount) => MonthesArray.Where(p => p.DaysCount == daysCount).DefaultIfEmpty();
    }
}
