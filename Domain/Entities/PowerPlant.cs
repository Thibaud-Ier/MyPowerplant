using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public abstract class PowerPlant : Entity
    {
        public override string Id => Name;

        public string Name { get; }

        public abstract Type TypeFuel { get; }

        public Rate Efficiency { get; }

        public PositiveValue MinimumPower { get; }

        public PositiveValue MaximumPower { get; }

        public PowerPlant(string name, Rate efficiency, PositiveValue minimumPower, PositiveValue maximumPower)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(nameof(name));
                
            if (minimumPower > maximumPower)
                throw new InvalidOperationException(nameof(name));

            Name = name;
            Efficiency = efficiency;
            MinimumPower = minimumPower;
            MaximumPower = maximumPower;
        }
    }
}
