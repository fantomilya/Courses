using System;

namespace Dz2
{
    struct Train
    {
        string stationName;
        int number;
        TimeSpan depatureTime;

        public Train(string stationName, int number, TimeSpan depatureTime)
        {
            this.stationName = stationName;
            this.number = number;
            this.depatureTime = depatureTime;
        }
        public override string ToString() => $"Поезд №{number.ToString()} отправляется со станции {stationName} в {depatureTime}";
    }
}
