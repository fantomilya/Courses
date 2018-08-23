using System;

namespace Dz1.Ducks
{
    public abstract class BaseDuck
    {
        public Action Talk;
        public Action Fly;
        public Action Show;
        public Action Swim;
        protected BaseDuck() : this(() => Console.WriteLine("I'm talking"), () => Console.WriteLine("I'm fliyng"), () => Console.WriteLine("I'm swiming")) { }

        protected BaseDuck(Action talk, Action fly, Action swim)
        {
            Talk = talk;
            Fly = fly;
            Swim = swim;
        }
    }
}
