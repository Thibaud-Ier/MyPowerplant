using Domain.Common;

namespace Domain.ValueObjects
{
    public class Percent : ValueObject<Percent>
    {
        public int Value { get; }

        public Rate Rate { get; }

        public Percent(int value)
        {
            if (value < 0 || value > 100)
                throw new InvalidOperationException();

            Value = value;
            Rate = new Rate((double)value / 100.0);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Rate;
        }
    }
}
