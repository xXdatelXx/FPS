namespace FPS.Tools
{
    public struct FloatWithStep
    {
        public readonly float Standard;
        public readonly float Step;

        public FloatWithStep(float step, float standard = 0)
        {
            Standard = standard;
            Step = step;
            Value = standard;
        }

        public float Value { get; private set; }

        public void Update() => Value += Step;
        public void Reset() => Value = Standard;
        
        public override string ToString() => Value.ToString();
    }
}