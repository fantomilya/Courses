using System.Collections.Generic;

namespace Dz8
{
    partial class Program
    {
        class CIniCustomer
        {
            public static List<Customer> IniCustomer()
            {
                List<Customer> customers = new List<Customer>()
                { new Customer { ID="A", City="Нью Йорк", Country="США",Region="Америка", Sales=9999},
                    new Customer { ID="B", City="Мумбаи",   Country="Индия",Region="Азия", Sales=8888 },
                    new Customer { ID="C", City="Токио",    Country="Япония",Region="Азия", Sales=7777 },
                    new Customer { ID="D", City="Дейли",    Country="Индия",Region="Азия", Sales=6666 },
                    new Customer { ID="E", City="Сан-Пауло",Country="Бразилия",Region="Америка",Sales=55},
                    new Customer { ID="F", City="Москва", Country="Россия",Region="Европа", Sales=4444 },
                    new Customer { ID="G", City="Сеул",   Country="Корея", Region="Азия",Sales=2222 },
                    new Customer { ID="H", City="Минск", Country="Беларусь", Region="Европа",Sales=9999 },
                    new Customer { ID="I", City="Берлин", Country="Германия", Region="Европа",Sales=500 },
                    new Customer { ID="J", City="Мадрид", Country="Испания", Region="Европа",Sales=3000 }
                };
                return customers;
            }
        }
    }
}
