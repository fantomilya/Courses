using System;

namespace Dz5
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private readonly EmployeeId id;
        public Employee(EmployeeId id, string name, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public override string ToString() => $"{id.ToString()} : {name,-20} {salary:C}";
    }

    public class EmployeeldException : Exception
    {
        public EmployeeldException(string message) : base(message) { }
    }

    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;

        public EmployeeId(string id)
        {
            if (id == null)
                throw new EmployeeldException("Employeeld does not to be equal null");

            prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (FormatException)
            {
                throw new EmployeeldException("Invalid Employeeld format");
            }
        }

        public bool Equals(EmployeeId other) => other != null && (ReferenceEquals(other, this) || (prefix == other.prefix && number == other.number));
        public override bool Equals(object obj) => obj != null && (ReferenceEquals(obj, this) || (obj is Employee emp && Equals(this, emp)));
        public override string ToString() => $"{prefix.ToString()}{number,6:000000}";
        public override int GetHashCode() => (number ^ number << 16) * 0x15051505;
        public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);
        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);

    }
}
