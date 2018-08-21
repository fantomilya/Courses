using System;

class BaseClass
{
    public virtual void Method()
    {
        Console.WriteLine("Method from BaseClass");
    }
}
class DerivedClass : BaseClass
{
    // Переопределение метода базового класса.

    public override void Method()
    {
        Console.WriteLine("Method from DerivedClass");
    }
}
class Derived : DerivedClass
{
    // Переопределение метода базового класса.

    public override void Method()
    {
        Console.WriteLine("Method from DerivedClass");
    }
}
class Program
{
    static void Main()
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
