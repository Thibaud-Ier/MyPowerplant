using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public abstract class PowerPlant : Entity
    {
        public override string Id => Name;

        public string Name { get; private init; }

        public Rate Efficiency { get; private init; }

        public PowerPlant(string name, Rate efficiency)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(nameof(name));
                
            Name = name;
            Efficiency = efficiency;
        }

        //        type: gasfired, turbojet or windturbine.

        //efficiency: the efficiency at which they convert a MWh of fuel into a MWh of electrical energy.
        //Wind-turbines do not consume 'fuel' and thus are considered to generate power at zero price.

        //pmax: the maximum amount of power the powerplant can generate.
        //pmin: the minimum amount of power the powerplant generates when switched on.
    }
}
