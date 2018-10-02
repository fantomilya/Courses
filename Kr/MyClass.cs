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

                if (delegates?.Select(p=>p.Target).Contains(value.Target) == true)
                {
                    Console.WriteLine("Объект, предоставляющий обработчик для события уже подписан");
                    return;
                }
                if (delegates?.Select(p => p.Method).Contains(value.Method) == true)
                {
                    Console.WriteLine("Конкретный метод-обработчик конкретного объекта уже подписан");
                    return;
                }

                HiddenEvent += value;
            }
            remove => HiddenEvent -= value;
        }
        private void Invoke()
        {
            var tmp = HiddenEvent;
            tmp?.Invoke(null, EventArgs.Empty);
        }
    }
}
