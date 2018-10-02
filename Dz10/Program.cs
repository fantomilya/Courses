using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace Dz10
{
    enum e
    {
        First,
        Second
    }
    class Program
    {
        public static List<object> types = new List<object> { @"Первый полет человека в космос" };//TCP\IP" };
        static void Task()
        {
            var a1 = Assembly.LoadFile(@"C:\FortBoyard\ClassLibrary1.dll");
            var a2 = Assembly.LoadFile(@"C:\FortBoyard\ClassLibrary2.dll");
            CheckOutAssembly(a1);
            Console.WriteLine();
            CheckOutAssembly(a2);
        }
        static object CreateInstance(TypeInfo type)
        {
            if (types.Any(p => p.GetType() == type))
                return types.First(p => p.GetType() == type);

            object instance;
            if (type.IsValueType)
            {
                instance = Activator.CreateInstance(type);
                types.Add(instance);
                return instance;

            }
            var ctor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).OrderBy(p => p.GetParameters().Count()).First();
            var parameters = ctor.GetParameters();
            if (parameters.Count() == 0)
            {
                instance = Activator.CreateInstance(type);
                types.Add(instance);
                return instance;

            }

            instance = Activator.CreateInstance(type, parameters.Select(p => CreateInstance(p.ParameterType.GetTypeInfo())));
            types.Add(instance);
            return instance;
        }
        static string GetValue(PropertyInfo pi, object obj)
        {
            var val = pi.GetValue(obj);
            if (val is string s)
                return s;
            if (val is null)
                return "null";
            if (val is IEnumerable e)
            {
                string res = "";
                foreach (var v in e)
                    res += ", " + v;

                return res.TrimStart(',', ' ');
            }

            return val.ToString();
        }
        static string GetValue(FieldInfo fi, object obj)
        {
            var val = fi.GetValue(obj);
            if (val is string s)
                return s;
            else if (val is null)
                return "null";
            else if (val is IEnumerable e)
            {
                string res = "";
                foreach (var v in e)
                    res += ", " + v.ToString();

                return res.TrimStart(',', ' ');
            }
            else
                return val.ToString();
        }
        static void CheckOutAssembly(Assembly a)
        {
            foreach (var t in a.GetTypes().Select(p=>p.GetTypeInfo()))
            {
                Console.WriteLine(t.ToString());
                var instance = CreateInstance(t);
                foreach (var v in t.GetMembers(BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine("\t" + v);
                    if (v is PropertyInfo pi)
                        Console.WriteLine("\t\t" + GetValue(pi, instance));
                    if (v is FieldInfo fi)
                        Console.WriteLine("\t\t" + GetValue(fi, instance));
                    else if (v is MethodInfo mi)
                    {
                        try
                        {
                            var parameters = mi.GetParameters();
                            if (!parameters.Any())
                                mi.Invoke(instance, null);
                            else
                                Console.WriteLine("\t\t" + mi.Invoke(instance, mi.GetParameters().Select(p => CreateInstance(p.ParameterType.GetTypeInfo())).ToArray())?.ToString() ?? "null");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("\t\t" + e.Message);
                        }
                    }
                }
                Console.WriteLine("\n" + new string('-', Console.WindowWidth));
            }
        }
        /*
            Реализовать метод, выполняющий логику системного метода Parse(Type enumType, string value, bool ignoreCase) из класса Enum
         */
        static object Parse(Type enumType, string value, bool ignoreCase)
        {
            value = ignoreCase ? value.ToLower() : value;
            foreach (var v in Enum.GetValues(typeof(e)))
            {
                var enumName = Enum.GetName(enumType, v);
                if ((ignoreCase? enumName.ToLower(): enumName) == value ||
                    int.TryParse(value, out var val) && (int)v == val)
                    return v;
            }

            throw new ArgumentException("Запрошенное значение не найдено.");
        }
        static void Main()
        {
            var asd = Parse(typeof(e), "12", true);
            var assembly1 = Assembly.LoadFile(@"C:\FortBoyard\ClassLibrary1.dll");

            var SecondClass = assembly1.GetType(@"ClassLibrary1.SecondClass");
            var SecondClassInstance = CreateInstance(SecondClass.GetTypeInfo());
            Console.WriteLine(SecondClass.GetMethod("HelpForDecode").Invoke(SecondClassInstance, new[] { "Первый полет человека в космос" }));

            var generatorType = assembly1.GetType("ClassLibrary1.GeneratorOfKeys");
            var generatorInstance = CreateInstance(generatorType.GetTypeInfo());
            generatorType.GetMethod("generator").Invoke(generatorInstance, null);
            foreach (var k in generatorType.GetField("arrayOfKeys").GetValue(generatorInstance) as IEnumerable<int>)
            {
                foreach (var v in "㼲㽮㼗㼔㽫㼑㼒㬍㬌㼾㽧㬌㼓㼒㼗㽯㽫㼔㼗㼔㬌㼛㼜㼘㼜㼑㼔㼙㬌㼑㼜㬌㼖㼞㼙㽭㽮㬂㬡㬦㼎㼙㼓㼙㽬㽠㬌㼒㼝㽬㼜㽮㼔㽮㼙㬌㼞㼑㼔㼐㼜㼑㼔㼙㬌㼑㼜㬌㼞㽮㼒㽬㽯㽢㬌㽭㼝㼒㽬㼖㽯㬂㬡㬦㼱㼜㼕㼘㽽㽮㼙㬌㼐㼙㽮㼒㼘㬀㬌㼖㼒㽮㼒㽬㽧㼕㬌㼐㼒㼚㼙㽮㬌㼓㽬㼔㼑㽣㽮㽠㬌㼛㼑㼜㽫㼙㼑㼔㼙㬌㬋㼳㽯㽭㼖㬋㬌㬓")
                    Console.Write((char)(v ^ k));

                Console.WriteLine();
            }


            var assembly2 = Assembly.LoadFile(@"C:\FortBoyard\ClassLibrary2.dll");
            var targetClassType = assembly2.GetType("ClassLibrary2.TargetClass");
            var targetClassInstance = CreateInstance(targetClassType.GetTypeInfo());
            targetClassType.GetMethod("Metod").Invoke(targetClassInstance, new[] { "Пуск" });

            var classWithCollectionType = assembly2.GetType("ClassLibrary2.ClassWithCollection");
            var classWithCollectionInstance = CreateInstance(classWithCollectionType.GetTypeInfo());
            dynamic d = classWithCollectionType.GetMethod("GenCollectOfCities").Invoke(classWithCollectionInstance, new[] { @"TCP\IP" });


            SortedDictionary<string, object> dict = new SortedDictionary<string, object>();
            foreach (dynamic v in d as IEnumerable)
                dict.Add(v.Name, v);

            classWithCollectionType.GetMethod("NextMetod").Invoke(classWithCollectionInstance, new[] { dict });

            Console.ReadKey();
        }
    }
}
