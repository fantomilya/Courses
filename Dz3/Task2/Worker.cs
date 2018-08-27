using System.Linq;

namespace Dz3
{
    public class Worker: IWorker
    {
        public int Productivity { get; private set; }

        public Worker(int productivity = 1) => Productivity = productivity;

        public void Work(House house)
        {
            if (house.Parts.FirstOrDefault(p => p.DonePercents < 100) is Part part)
                part.Build(Productivity);
        }
    }
}
