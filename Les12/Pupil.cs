namespace Les12
{
    public abstract class Pupil
    {
        protected string GetMastery() =>
            _mastery == PupilMastery.Excellent ? "превосходно" :
            _mastery == PupilMastery.Good ? "хорошо" :
            _mastery == PupilMastery.Bad ? "плохо" : "";

        private readonly PupilMastery _mastery;

        protected Pupil(PupilMastery mastery) => _mastery = mastery;
        public virtual string Study() => "учится";
        public virtual string Write() => "пишет";
        public virtual string Read() => "читает";
        public virtual string Relax() => "отдыхает";
        public override string ToString() => $"{Study()}, {Write()}, {Read()}, {Relax()}";
    }
    public enum PupilMastery
    {
        Excellent,
        Good,
        Bad
    }

    public class ExcellentPupil : Pupil
    {
        public ExcellentPupil() : base(PupilMastery.Excellent) { }
        public override string Study() => GetMastery() + " " + base.Study();
        public override string Write() => GetMastery() + " " + base.Write();
        public override string Read() => GetMastery() + " " + base.Read();
        public override string Relax() => GetMastery() + " " + base.Relax();
    }
    public class GoodPupil : Pupil
    {
        public GoodPupil() : base(PupilMastery.Good) { }
        public override string Study() => GetMastery() + " " + base.Study();
        public override string Write() => GetMastery() + " " + base.Write();
        public override string Read() => GetMastery() + " " + base.Read();
        public override string Relax() => GetMastery() + " " + base.Relax();
    }
    public class BadPupil : Pupil
    {
        public BadPupil() : base(PupilMastery.Bad) { }
        public override string Study() => GetMastery() + " " + base.Study();
        public override string Write() => GetMastery() + " " + base.Write();
        public override string Read() => GetMastery() + " " + base.Read();
        public override string Relax() => GetMastery() + " " + base.Relax();
    }
}