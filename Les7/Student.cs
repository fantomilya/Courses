namespace Les7
{
    internal class Student
    {
        public static string UniversityName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        static Student()
        {
            UniversityName = "-";
        }

        public Student() : this("", "", 0) { }

        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override string ToString() => $"Студент {Surname} {Name}. Возраст - {Age}.";
    }
}