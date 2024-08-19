using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public class Gasfired(string name, Rate efficiency, PositiveIntValue minimumPower, PositiveIntValue maximumPower)
        : PowerPlant(name, efficiency, minimumPower, maximumPower)
    {
        public override Type TypeFuel => typeof(Gas);
    }
}
