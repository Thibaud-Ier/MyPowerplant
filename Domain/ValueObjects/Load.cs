using Domain.Common;

namespace Domain.ValueObjects
{
    public class Load(PositiveValue value) : ValueObject<Load>
    {
        public PositiveValue Value { get; } = value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
