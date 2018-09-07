using System;

namespace Les8
{
    internal class Program
    {
        private static void Main()
        {
            Stack stk1 = new Stack(10);
            Stack stk2 = new Stack(10);
            Stack stk3 = new Stack(10);
            int i;
            // Помещаем ряд символов в стек stk1.
            Console.WriteLine("Помещаем символы от А до Z в стек stk1.");

            for (i = 0; !stk1.Full(); i++)
                stk1.Push((char)('A' + i));

            if (stk1.Full()) Console.WriteLine("Стек stk1 полон.");

            // Отображаем содержимое стека stkl.
            Console.Write("Содержимое стека stk1: ");
            while (!stk1.Empty())
                Console.Write(stk1.Pop());

            Console.WriteLine();

            if (stk1.Empty()) Console.WriteLine("Стек stk1 пуст.\n");

            // Помещаем еще символы в стек stk1.
            Console.WriteLine("Снова помещаем символы от А до Z в стек stk1.");
            for (i = 0; !stk1.Full(); i++)
                stk1.Push((char)('A' + i));

            /* Теперь извлекаем элементы из стека stk1 и помещаем их в стек stk2.
            В результате элементы стека stk2 должны быть расположены в обратном порядке. */

            Console.WriteLine("Теперь извлекаем элементы из стека stkl и\n" +
                               " помещаем их в стек stk2.");
            while (!stk1.Empty())
                stk2.Push(stk1.Pop());

            Console.Write("Содержимое стека stk2: ");
            while (!stk2.Empty())
                Console.Write(stk2.Pop());

            Console.WriteLine("\n");

            // Помещаем 5 символов в стек stk3.
            Console.WriteLine("Помещаем 5 символов в стек stk3.");
            for (i = 0; i < 5; i++)
                stk3.Push((char)('A' + i));

            Console.WriteLine("Объем стека stk3: " + stk3.Capacity());
            Console.WriteLine("Количество объектов в стеке stk3: " + stk3.GetNum());

            Console.ReadKey();
        }
    }

    internal class Stack
    {
        // Эти члены закрытые.
        private char[] _stack; // Массив для хранения данных стека.
        private int _count; // Индекс вершины стека.
        
        // Создаем пустой класс Stack заданного размера,
        public Stack(int size)
        {
            _stack = new char[size]; // Выделяем память для стека.
            _count = 0;
        }
        // Помещаем символы в стек.
        public void Push(char ch)
        {
            if (_count == _stack.Length)
            {
                Console.WriteLine(" - Стек заполнен.");
                return;
            }
            _stack[_count] = ch;
            _count++;
        }
        // Извлекаем символ из стека,
        public char Pop()
        {
            if (_count == 0)
            {
                Console.WriteLine(" - Стек пуст.");
                return (char)0;
            }
            _count--;
            return _stack[_count];
        }
        // Метод возвращает значение true, если стек полон,
        public bool Full() => _count == _stack.Length;
        // Метод возвращает значение true, если стек пуст,
        public bool Empty() => _count == 0;
        // Возвращает общий объем стека,
        public int Capacity() => _stack.Length;
        // Возвращает текущее количество объектов в стеке,
        public int GetNum() => _count;
    }
}
