using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public class Gasfired(string name, Rate efficiency, PositiveIntValue minimumPower, PositiveIntValue maximumPower)
        : PowerPlant(name, efficiency, minimumPower, maximumPower)
    {
        private const double CO2_EMISSION = 0.3;

        public override Type TypeFuel => typeof(Gas);

        public override double GetCostByMegaWattOfFuel(Fuel fuel, CO2 co2)
        {
            return base.GetCostByMegaWattOfFuel(fuel, co2) + (CO2_EMISSION * co2.Value.Value);
        }
    }
}
