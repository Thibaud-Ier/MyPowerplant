﻿using Domain.Common;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public abstract class PowerPlant : Entity
    {
        public override string Id => Name;

        public string Name { get; }

        public abstract Type TypeFuel { get; }

        public Rate Efficiency { get; }

        public PositiveIntValue MinimumPower { get; }

        public PositiveIntValue MaximumPower { get; }

        public PowerPlant(string name, Rate efficiency, PositiveIntValue minimumPower, PositiveIntValue maximumPower)
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

        public virtual double GetEffectiveMinimumPower(Fuel fuel)
        {
            AssertRightFuel(fuel);

            return MinimumPower.Value;
        }

        public virtual double GetEffectiveMaximumPower(Fuel fuel)
        {
            AssertRightFuel(fuel);

            return MaximumPower.Value;
        }

        public virtual double GetCostByMegaWattOfFuel(Fuel fuel, CO2 co2)
        {
            AssertRightFuel(fuel);

            return fuel.Value.Value / Efficiency.Value;
        }

        private void AssertRightFuel(Fuel fuel)
        {
            if (TypeFuel != fuel.GetType())
                throw new InvalidOperationException();
        }
    }
}
