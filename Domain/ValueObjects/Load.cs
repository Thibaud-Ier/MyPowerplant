using Domain.Common;

namespace Domain.ValueObjects
{
    public class Load(PositiveIntValue value) : ValueObject<Load>
    {
        public PositiveIntValue Value { get; } = value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
