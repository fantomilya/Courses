namespace Dz4
{
    struct Purchase
    {
        public string Purchaser { get; }
        public string Category { get; }

        public Purchase(string purchaser, string category) : this()
        {
            Purchaser = purchaser;
            Category = category;
        }
    }
}
