namespace Dz4
{
    struct Month
    {
        public Month(MonthName name, int daysCount)
        {
            this.daysCount = daysCount;
            this.name = name;
        }

        public int daysCount { get; }
        public MonthName name { get; }
        public override string ToString() => $"{name.ToString()}({daysCount.ToString()})";
    }
}
