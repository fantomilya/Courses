using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    internal class MyInternalClass
    {
        public MyInternalClass()
        {
            Console.WriteLine("Constructor - MyInternalClassA");
        }
    }

    public class MyPublicClass
    {
        public void PublicMethod()
        {
            Console.WriteLine("PublicMethod");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("InternalMethod");
        }

        // internal protected - Доступ к типу или члену возможен из любого кода в этой сборке, или из производного класса в другой сборке.
        internal protected void InternalProtectedMethod()
        {
            Console.WriteLine("InternalProtectedMethod");
        }
    }

}
