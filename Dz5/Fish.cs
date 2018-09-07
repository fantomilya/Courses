using System.Collections;
using System.Collections.Generic;

namespace Dz5
{
    public class Fish
    {
        public string Name { get; }
        public Fish(string name) => Name = name;
    }

    public class InsensitiveComparer : IEqualityComparer<Fish>
    {
        private static readonly CaseInsensitiveComparer Comparer = new CaseInsensitiveComparer();
        public int GetHashCode(Fish str) => str.Name.ToLower().GetHashCode();
        public bool Equals(Fish fish1, Fish fish2) => fish1 != null && fish2 != null && (ReferenceEquals(fish1, fish2) || Comparer.Compare(fish1.Name, fish2.Name) == 0);
    }
}
