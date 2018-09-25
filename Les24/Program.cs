using System;
using System.Collections.Generic;
using System.Linq;

namespace Les24
{
    public class EmployeeID
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeNationality
    {
        public string Id { get; set; }
        public string Nationality { get; set; }
    }
    public class Result
    {
        public Result(int input, int output)
        {
            Input = input;
            Output = output;
        }

        public int Input { get; set; }
        public int Output { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4 };

            var query = from x in numbers
                select new Result(x, x * 2);

            numbers[0] = 777;

            foreach (var item in query)
                Console.WriteLine("Input = {0}, \t Output = {1}", item.Input, item.Output);

            Console.ReadKey();
        }
    }

    class Program1
    {
        static void Main1()
        {
            var employees = new List<EmployeeID>
            {
                new EmployeeID {Id = "111", Name = "Ivan Ivanov"},
                new EmployeeID {Id = "222", Name = "Andrey Andreev"},
                new EmployeeID {Id = "333", Name = "Petr Petrov"},
                new EmployeeID {Id = "444", Name = "Alex Alexeev"}
            };

            var empNationalities = new List<EmployeeNationality>
            {
                new EmployeeNationality {Id = "111", Nationality = "Russian"},
                new EmployeeNationality {Id = "222", Nationality = "Ukrainian"},
                new EmployeeNationality {Id = "333", Nationality = "American"},
            };

            var q = employees.Join(empNationalities, p => p.Id, p => p.Id, (emp, nationality) => new { emp, nationality }).OrderBy(p => p.nationality.Nationality).Select(p => new { Id = p.emp.Id, Name = p.emp.Name, Nationality = p.nationality.Nationality });
           
            var query = from emp in employees
                        join n in empNationalities
                            on emp.Id equals n.Id
                        orderby n.Nationality descending
                        select new
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Nationality = n.Nationality
                        };

            foreach (var person in q)
                Console.WriteLine("{0}, {1}, \t{2}", person.Id, person.Name, person.Nationality);

            Console.ReadKey();
        }
    }

}
