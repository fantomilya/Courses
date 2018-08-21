using System;

interface IInterface
{
    void Method();
}

class BaseClass
{
    public void Method()
    {
        Console.WriteLine("BaseClass.Method()");
    }
}

class DerivedClass : BaseClass, IInterface
{
    // Реализация интерфейса не обязательна, т.к., 
    // сигнатуры методов в классе и интерфейсе совпадают.
}

class Program
{
    static void Main()
    {
        DerivedClass instance = new DerivedClass();
        instance.Method();

        ((IInterface) instance).Method();

        Console.ReadKey();
    }
}
