using Domain.Common;

namespace Domain.ValueObjects
{
    public class Rate : ValueObject<Rate>
    {
        public double Value { get; }

        public Rate(double value)
        {
            if (value < 0 || value > 1)
                throw new InvalidOperationException();

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
