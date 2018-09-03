using System;

namespace Dz4
{
    class Auto :IComparable<Auto>
    {
        private string carname;
        private int maxspeed;
        private double cost;
        private byte discount;
        private int id;

        public string Carname { get => carname; set => carname = value; }
        public int Maxspeed { get => maxspeed; set => maxspeed = value; }
        public double Cost { get => cost; set => cost = value; }
        public byte Discount { get => discount; set => discount = value; }
        public int Id { get => id; set => id = value; }
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
        public int CompareTo(Auto other) => (Cost - (Cost * discount / 100D)).CompareTo(other.Cost - (other.Cost * other.discount / 100D));
    }
}
