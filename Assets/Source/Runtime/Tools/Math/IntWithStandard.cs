namespace Source.Runtime.Tools.Math
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

        public bool StandardEqualsValue => Standard == Value;

        public void Reset()
        {
            Value = Standard;
        }
    }
}