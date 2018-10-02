#define PREMIUM   // Символ с указанным именем существует

using System;
using System.Diagnostics;
using System.Reflection;

namespace Attributes
{
    [Obsolete] // Класс следует считать устаревшим.
    class Test
    {
        [Conditional("TRIAL")]
        void Trial()
        {
            Console.WriteLine("Пробная версия.");
        }

        [Conditional("PREMIUM")]
        void Release()
        {
            Console.WriteLine("Платная версия.");
        }

#if DEBUG
        private void Initialize()
        {
            Console.WriteLine("Инициализация приложения в режиме DEBUG");
        }
#else
        private void Initialize()
        {
            Console.WriteLine("Инициализация приложения в режиме RELEASE");
        }
#endif

        static void Main()
        {
            Test test = new Test();

            test.Initialize();
            test.Trial();   // Вызывается только в том случае, если определен идентификатор TRIAL 
            test.Release(); // Вызывается только в том случае, если определен идентификатор RELEASE 
            Console.WriteLine(new string('-', 20));

            Type type = typeof(Test);

            MethodInfo[] methodInfo = type.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methodInfo)
                Console.WriteLine(method.Name);

            Console.ReadKey();
        }
    }
}
