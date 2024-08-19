using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Api.DTO
{
    public static class FuelFactory
    {
        public static Fuel MakeFuel(string name, double value)
        {
            return name switch
            {
                "gas(euro/MWh)" => new Gas(new PositiveDoubleValue(value)),
                "kerosine(euro/MWh)" => new Kerosine(new PositiveDoubleValue(value)),
                "co2(euro/ton)" => new CO2(new PositiveDoubleValue(value)),
                "wind(%)" => new Wind(new Percent((int)value)),
                _ => throw new ArgumentException("Fuel"),
            };
        }
    }
}
