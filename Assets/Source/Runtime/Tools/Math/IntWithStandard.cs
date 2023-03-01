namespace FPS.Tools
{
    public struct IntWithStandard
    {
        public readonly int Standard;
        public int Value;

        public IntWithStandard(int value)
        {
            Standard = value;
            Value = value;
        }

        public bool StandardEqualsValue => Standard == Value;
        public void Reset() => Value = Standard;

        public static IntWithStandard operator ++(IntWithStandard i)
        {
            i.Value++;
            return i;
        }

        public static IntWithStandard operator --(IntWithStandard i)
        {
            i.Value--;
            return i;
        }

        public static bool operator >(IntWithStandard a, int b) => a.Value > b;
        public static bool operator <(IntWithStandard a, int b) => a.Value < b;

        public override string ToString() => Value.ToString();
    }
}