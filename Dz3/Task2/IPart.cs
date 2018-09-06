using System;

namespace Dz3
{
    /*2) Реализовать программу “Строительство дома”.
        Реализовать:
        - классы 
        • House (Дом), Basement (Фундамент), Walls (Стены), Door (Дверь), Window (Окно), Roof (Крыша); 
        • Team (Бригада строителей), Worker (Строитель), TeamLeader (Бригадир), 
        - интерфейсы 
        • IWorker, IPart.
        Все части дома должны реализовать интерфейс IPart (Часть дома), для рабочих и бригадира предоставляется базовый интерфейс IWorker (Рабочий).
        Бригада строителей (Team) строит дом (House). Дом состоит из фундамента (Basement), стен (Wall), окон (Window), дверей (Door), крыши (Part).
        Согласно проекту, в доме должно быть 1 фундамент, 4 стены, 1 дверь, 4 окна и 1 крыша.
        Бригада начинает работу, и строители последовательно “строят” дом, начиная с фундамента. Каждый строитель не знает заранее, на чём завершился предыдущий этап строительства, поэтому он “проверяет”, что уже построено и продолжает работу.
        Если в игру вступает бригадир (TeamLeader), он не строит, а формирует отчёт, что уже построено и какая часть работы выполнена.
        В конечном итоге на консоль выводится сообщение, что строительство дома завершено и отображается “рисунок дома” (вариант отображения выбрать самостоятельно).
     */
    public abstract class Part
    {
        public double BuiltTime { get; private set; }
        public double DonePercents { get; private set; }
        public Func<string> GetName { get; private set; }

        protected Part(double builtTime, Func<string> GetName)
        {
            BuiltTime = builtTime;
            DonePercents = 0;
            this.GetName = GetName;
        }

        public void Build(int productivity)
        {
            DonePercents += productivity * 100 / BuiltTime;

            if (DonePercents > 100)
                DonePercents = 100;
        }
    }

    internal class Basement : Part
    {
        public Basement():base(150, ()=> "фундамент") { }
    }

    internal class Wall : Part
    {
        public Wall() : base(120, () => "стена") { }
    }

    internal class Door : Part
    {
        public Door() : base(60, () => "дверь") { }
    }

    internal class Window : Part
    {
        public Window() : base(40, () => "окно") { }
    }

    internal class Roof : Part
    {
        public Roof() : base(130, () => "крыша") { }
    }
}
