using System;

namespace Dz4
{
    internal class Auto :IComparable<Auto>
    {
        public string Carname { get; set; }
        public int Maxspeed { get; set; }
        public double Cost { get; set; }
        public byte Discount { get; set; }
        public int Id { get; set; }

        public Auto()
        {

        }
        public Auto(string carname, int maxspeed, double cost, byte discount, int id)
        {
            Carname = carname;
            Maxspeed = maxspeed;
            Cost = cost;
            Discount = discount;
            Id = id;
        }
        public override string ToString() => $"{Id}\tМарка: {Carname}\tМакс. скорость: {Maxspeed}\tЦена: {Cost:C}\tСкидка: {Discount}%";
        public int CompareTo(Auto other) => (Cost - Cost * Discount / 100D).CompareTo(other.Cost - other.Cost * other.Discount / 100D);
    }
}
