using System.Collections.Generic;

namespace Les12
{
    public class ClassRoom : List<Pupil>
    {
        public ClassRoom() : this(new GoodPupil(), new BadPupil(), new ExcellentPupil(), new GoodPupil()) { }
        public ClassRoom(Pupil p) => Add(p);
        public ClassRoom(Pupil p1, Pupil p2) : this(new[] { p1, p2 }) { }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3) : this(new[] { p1, p2, p3 }) { }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3, Pupil p4) : this(new[] { p1, p2, p3, p4 }) { }

        private ClassRoom(params Pupil[] pupils) => AddRange(pupils);
    }
}

