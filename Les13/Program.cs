using System;

internal interface IInterface
{
    void Method();
}

internal class BaseClass
{
    public void Method()
    {
        Console.WriteLine("BaseClass.Method()");
    }
}

internal class DerivedClass : BaseClass, IInterface
{
    // Реализация интерфейса не обязательна, т.к., 
    // сигнатуры методов в классе и интерфейсе совпадают.
}

internal class Program
{
    private static void Main()
    {
        DerivedClass instance = new DerivedClass();
        instance.Method();

        ((IInterface) instance).Method();

        Console.ReadKey();
    }
}
