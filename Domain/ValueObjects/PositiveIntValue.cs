using Domain.Common;

namespace Domain.ValueObjects
{
    public class PositiveIntValue : ValueObject<PositiveIntValue>
    {
        public int Value { get; }

        public PositiveIntValue(int value)
        {
            if (value < 0)
                throw new InvalidOperationException();

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator >(PositiveIntValue a, PositiveIntValue b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(PositiveIntValue a, PositiveIntValue b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >=(PositiveIntValue a, PositiveIntValue b)
        {
            return a.Value >= b.Value;
        }

        public static bool operator <=(PositiveIntValue a, PositiveIntValue b)
        {
            return a.Value <= b.Value;
        }
    }
}
