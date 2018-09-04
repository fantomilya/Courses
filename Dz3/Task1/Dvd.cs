using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    class Dvd : Storage
    {
        double speed;
        Type type;
        List<File> files = new List<File>();

        public Dvd(Type type, double speed, string name, string model):base(name, model)
        {
            this.type = type;
            this.speed = speed;
        }

        public override double CalcTime(double size) => size * 1024 * 1024 / speed;

        public override void Clear() => files.Clear();

        public override double Copy(params File[] files)
        {
            double time = 0;
            foreach (var file in files)
            {
                if (GetFreeMemory() > file.size)
                {
                    this.files.Add(file);
                    time += CalcTime(file.size);
                }
                else
                    break;
            }
            return time;
        }

        public override double GetCapacity() => type == Type.OneSided ? 4.7 : 9;

        public override double GetFreeMemory() => (type == Type.OneSided ? 4.7 : 9) - files.Sum(p => p.size);

        public override string GetInfo() => $"DVD {base.ToString()} скорость {speed.ToString()} КБ/c, тип {type.ToString()}, свободное место {GetFreeMemory().ToString()} ГБ";
    }
}
