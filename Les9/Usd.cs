using System;

namespace Les9
{
    public class Usd
    {
        public uint doll { get; private set; }
        public ushort cent { get; private set; }
        public Usd(uint doll, ushort cent)
        {
            this.doll = doll;
            this.cent = cent;
        }

        public static explicit operator float(Usd v) => v.doll + (float)(v.cent / Math.Pow(10, v.cent.ToString().Length));

        public static implicit operator Usd(float v) => new Usd((uint)v, (ushort)((int)(v * 100) % 100));
        public override string ToString() => $"{doll},{cent}$";

    }
}