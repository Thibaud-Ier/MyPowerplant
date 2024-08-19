using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public class Windturbine(string name, PositiveValue minimumPower, PositiveValue maximumPower)
        : PowerPlant(name, new Rate(1), minimumPower, maximumPower)
    {
        public override Type TypeFuel => typeof(Gas);
    }
}
