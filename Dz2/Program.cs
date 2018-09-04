using System;

namespace Dz2
{
    class Program
    {
        private static void Main()
        {

            SortedTrains trains = new SortedTrains();
            trains.InsertTrains();
            trains.SearchTrain();

            SortedWorkers workers = new SortedWorkers();
            workers.InputWorkersRand();
            workers.SearchWorker();

            Console.ReadKey(true);
        }

    }
}
