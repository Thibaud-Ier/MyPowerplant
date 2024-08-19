﻿using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.Entities
{
    public class Turbojet(string name, Rate efficiency, PositiveValue minimumPower, PositiveValue maximumPower)
        : PowerPlant(name, efficiency, minimumPower, maximumPower)
    {
        public override Type TypeFuel => typeof(Kerosine);
    }
}
