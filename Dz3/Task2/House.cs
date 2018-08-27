using System.Collections.Generic;

namespace Dz3
{
    public class House
    {
        public List<Part> Parts { get; private set; }

        public House() : this(new Basement(), new Wall(), new Wall(), new Wall(), new Wall(), new Door(), new Window(), new Window(), new Window(), new Window(), new Roof()) { }

        public House(params Part[] parts) => Parts = new List<Part>(parts);
    }
}
