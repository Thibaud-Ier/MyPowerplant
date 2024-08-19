using Domain.Common;

namespace Domain.ValueObjects
{
    public class PositiveValue : ValueObject<PositiveValue>
    {
        public int Value { get; }

        public PositiveValue(int value)
        {
            if (value < 0)
                throw new InvalidOperationException();

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
