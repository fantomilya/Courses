using Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dz6
{
    enum GenderEnum
    {
        Male,
        Female
    }
    class Person : IEquatable<Person>
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public GenderEnum? Gender { get; private set; }
        public static Random rand = new Random();
        public Person()
        {

        }
        public static Person GenerateRandom()
        {
            GenderEnum gender = rand.OneOf(GenderEnum.Male, GenderEnum.Female);
            var name = gender == GenderEnum.Male ? rand.OneOf("Илья", "Василий", "Александр", "Евгений", "Валентин", "Антон", "Борис", "Валера", "Павел")
                                                 : rand.OneOf("Алина", "Татьяна", "Алёна", "Яна", "Ольга", "Инна", "Вероника", "Анна", "Наталья", "Елизаветта");
            var surname = rand.OneOf("Васильев", "Петров", "Смирнов", "Михайлов", "Фёдоров", "Соколов", "Яковлев", "Попов", "Андреев", "Алексеев", "Александров", "Лебедев", "Григорьев", "Степанов", "Семёнов", "Павлов", "Богданов", "Николаев", "Дмитриев") + (gender == GenderEnum.Female ? "а" : "");

            var patronymic = rand.OneOf("Ивановна", "Степановна", "Петровна", "Павловна", "Антоновна", "Борисовна", "Олеговна", "Игоревна", "Алексеевна", "Михайловна", "Владимировна", "Александровна", "Валентиновна", "Евгеньевна", "Валерьевна");
            
            if (gender == GenderEnum.Male)
                patronymic = patronymic.CutRight(2) + "ич";

            var birthDate = rand.NextBool(20) ? null : (DateTime?)rand.NextDate(new DateTime(1920, 01, 01), DateTime.Today);

            return new Person(name, surname, patronymic, birthDate, rand.NextBool(20) ? null : (GenderEnum?)gender);
        }
        public Person(string name, string surname, string patronymic, DateTime? birthDate = null, GenderEnum? gender = null)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Gender = gender;
        }
        public Person(string fileName)
        {
            var remainedItems = string.Empty;
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                Name = sr.ReadLine();
                Surname = sr.ReadLine();
                Patronymic = sr.ReadLine();
                try
                {
                    BirthDate = DateTime.Parse(sr.ReadLine());
                }
                catch { }
                try
                {
                    Gender = (GenderEnum)int.Parse(sr.ReadLine());
                }
                catch { }
                remainedItems = sr.ReadToEnd();
            }
            if (string.IsNullOrWhiteSpace(remainedItems))
                new FileInfo(fileName).Delete();
            else
                using (var sw = new StreamWriter(fileName, false, Encoding.Default))
                    sw.WriteLine(remainedItems);

        }

        public bool WriteToFile(string fileName, FileMode fileMode = FileMode.Append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, fileMode), Encoding.Default))
                    foreach (var s in new[] { Name, Surname, Patronymic, BirthDate?.ToString() ?? "", ((int?)Gender).ToString() ?? "" })
                        sw.WriteLine(s);

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Не удалось сохранить в файл: " + ex.Message);
                return false;
            }
        }
        public override string ToString() => $"{Surname} {Name} {Patronymic}{(BirthDate.HasValue ? ", Дата рождения: " + BirthDate?.ToString("dd-MM-yyyy") : "")}\n{(Gender.HasValue ? ", Пол: " + Gender.ToString() : "")}";

        public bool Equals(Person other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return BirthDate == other.BirthDate && Gender == other.Gender && Name == other.Name && Patronymic == other.Patronymic && Surname == other.Surname;
        }

        public override bool Equals(Object other) => ReferenceEquals(other, this) || (other is Person p && Equals(p));

        public override int GetHashCode()
        {
            var hashCode = -1215169427;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Patronymic);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(BirthDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<GenderEnum?>.Default.GetHashCode(Gender);
            return hashCode;
        }

        public static bool operator ==(Person p1, Person p2) => (p1 is null && p2 is null) || p1?.Equals(p2) == true;
        public static bool operator !=(Person p1, Person p2) => !(p1 == p2);
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = Enumerable.Range(1, 15).Select(p => Person.GenerateRandom()).ToList();
            File.Create("persons.txt").Close();

            foreach (var p in persons)
                p.WriteToFile("persons.txt", FileMode.Append);

            for (int i = persons.Count - 1; i >= 0; i--)
                persons[i] = new Person("persons.txt");

            persons[3].WriteToFile("tmp.txt", FileMode.Create);
            var person = new Person("tmp.txt");
            Console.WriteLine(persons[3] == person);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.ReadKey(true);
        }
    }
}
