using System;
using System.Linq;

namespace Kr
{
    public class MyClass
    {
        private event EventHandler HiddenEvent;
        public event EventHandler OnSomeAction
        {
            add
            {
                if (value == null)
                    return;

                var delegates = HiddenEvent?.GetInvocationList();

                if (delegates?.Contains(value) == true)
                {
                    Console.WriteLine("Объект, предоставляющий обработчик для события уже подписан");
                    return;
                }
                var inv = value.GetInvocationList();
                if (value.Target != null && value.Method != null && delegates?.Any(p => p.GetInvocationList().Any(m => inv.Contains(m))) == true)
                {
                    Console.WriteLine("Конкретный метод-обработчик конкретного объекта уже подписан");
                    return;
                }
                else
                {
                    HiddenEvent += value;
                }
            }
            remove
            {
                HiddenEvent -= value;
            }
        }
        private void Invoke()
        {
            var tmp = HiddenEvent;
            tmp?.Invoke(null, EventArgs.Empty);
        }
    }
}
