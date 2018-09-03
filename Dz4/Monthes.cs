using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Monthes : IEnumerable<Month>
    {
        Month[] monthes;
        public Monthes()
        {
            monthes = new Month[12];
            for (int i = 1; i < 13; i++)
                monthes[i - 1] = new Month((MonthName)i, DateTime.DaysInMonth(DateTime.Today.Year, i));
        }
        public Month this[int index] => index > 0 && index < 13 ? monthes[index - 1] : default(Month);

        public IEnumerator<Month> GetEnumerator()
        {
            foreach (var v in monthes)
                yield return v;
        }

        public IEnumerable<Month> GetMonthesByDaysCount(int daysCount) => monthes.Where(p => p.daysCount == daysCount).DefaultIfEmpty();

        IEnumerator IEnumerable.GetEnumerator() => monthes.GetEnumerator();
    }
}
