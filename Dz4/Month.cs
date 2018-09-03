namespace Dz4
{
    struct Month
    {
        public int DaysCount { get; }
        public MonthName Name { get; }

        public Month(MonthName name, int daysCount)
        {
            this.DaysCount = daysCount;
            this.Name = name;
        }

        public override string ToString() => $"{Name.ToString()}({DaysCount.ToString()})";
    }
}
