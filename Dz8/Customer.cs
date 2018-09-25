namespace Dz8
{
    partial class Program
    {
        class Customer
        {
            public string ID { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Region { get; set; }
            public decimal Sales { get; set; }
            public override string ToString() => "ID: " + ID + " Город: " + City + " Страна: " + Country + " Регион: " + Region + " Продажи: " + Sales;
        }
    }
}
