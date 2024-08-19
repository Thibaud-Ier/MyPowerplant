using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public class Windturbine(string name, PositiveIntValue minimumPower, PositiveIntValue maximumPower)
        : PowerPlant(name, new Rate(1), minimumPower, maximumPower)
    {
        public override Type TypeFuel => typeof(Wind);

        public override double GetEffectiveMinimumPower(Fuel fuel)
            => base.GetEffectiveMinimumPower(fuel) * fuel.Value.Value;

        public override double GetEffectiveMaximumPower(Fuel fuel)
            => base.GetEffectiveMaximumPower(fuel) * fuel.Value.Value;

        public override double GetCostByMegaWattOfFuel(Fuel fuel, CO2 co2)
        {
            return base.GetCostByMegaWattOfFuel(fuel, co2) * 0;
        }
    }
}
