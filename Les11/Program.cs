using System;

internal class BaseClass
{
    public virtual void Method()
    {
        Console.WriteLine("Method from BaseClass");
    }
}

internal class DerivedClass : BaseClass
{
    // Переопределение метода базового класса.

    public override void Method()
    {
        Console.WriteLine("Method from DerivedClass");
    }
}

internal class Derived : DerivedClass
{
    // Переопределение метода базового класса.

    public override void Method()
    {
        Console.WriteLine("Method from DerivedClass");
    }
}

internal class Program
{
    private static void Main()
    {
        DerivedClass instance = new DerivedClass();
        instance.Method();

        // UpCast
        BaseClass instanceUp = instance;
        instanceUp.Method();

        // DownCast
        DerivedClass instanceDown = (DerivedClass)instanceUp;
        instanceDown.Method();

        Console.ReadKey();
    }
}
