using Extensions;
using System;
using System.Linq;

namespace Les10
{
    class Store: MyList<Article>
    {
        public Store():this(5)
        {

        }
        public Store(int count):base(count)
        {
            AddRange(new Article("Велик", "Велостор", 100), new Article("Айфон", "ЭплСтор", 100), new Article("Лопата", "хз", 5));
        }

        public new string this[int index]
        {
            get => (this as MyList<Article>)[index].ToString();
        }
        public string this[string index]
        {
            get => this.Where(p => p.Name.ToLower() == index.ToLower()).GetString(defaultIfEmpty: "Ничего нет");
        }
    }
    class Article :IComparable<Article >
    {
        public string Name { get; set; }
        public string Market { get; set; }
        public double Price { get; set; }

        public Article(string name, string market, double price)
        {
            Name = name;
            Market = market;
            Price = price;
        }

        public override string ToString() => $"{Name} - {Market} - {Price}";
        public int CompareTo(Article other) => Name.CompareTo(other.ToString());
    }
}