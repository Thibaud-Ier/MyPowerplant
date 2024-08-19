using Domain.Common;

namespace Domain.ValueObjects
{
    public class Load : ValueObject<Load>
    {
        public int Value { get; }

        public Load(int value)
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
