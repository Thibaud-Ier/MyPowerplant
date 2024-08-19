using Domain.Common;

namespace Domain.ValueObjects.Fuels
{
    public abstract class Fuel : ValueObject<Fuel>
    {
        public abstract string Name { get;}

        public abstract double Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Value;
        }
    }
}
