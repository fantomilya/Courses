using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    class Team
    {
        List<IWorker> workers;

        public void Build(House house)
        {
            while (house.Parts.Any(p=>p.DonePercents < 100))
                foreach (var v in workers)
                    v.Work(house);

            Console.WriteLine(@"
    /\
   /  \
  /    \
 /______\
 | o  o |
 |   _  |
 |  | | |
 |  |_| |
 --------");
        }
        public Team(): this(new TeamLeader(), new Worker(3), new Worker(6), new Worker(), new Worker(2), new Worker(5)) { }
        public Team(params IWorker[] workers) => this.workers = new List<IWorker>(workers);
    }
}
