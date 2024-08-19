using Domain.Common;

namespace Domain.ValueObjects
{
    public class PositiveDoubleValue : ValueObject<PositiveDoubleValue>
    {
        public double Value { get; }

        public PositiveDoubleValue(double value)
        {
            if (value < 0)
                throw new InvalidOperationException();

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator >(PositiveDoubleValue a, PositiveDoubleValue b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(PositiveDoubleValue a, PositiveDoubleValue b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >=(PositiveDoubleValue a, PositiveDoubleValue b)
        {
            return a.Value >= b.Value;
        }

        public static bool operator <=(PositiveDoubleValue a, PositiveDoubleValue b)
        {
            return a.Value <= b.Value;
        }
    }
}
