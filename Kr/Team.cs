﻿using System.Collections.Generic;

namespace Kr
{
    public class Team
    {
        public Team(string name, params int[] years)
        {
            Name = name;
            Years = new List<int>(years);
        }
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }
    }
}
