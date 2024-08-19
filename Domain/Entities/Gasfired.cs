using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gasfired(string name, Rate efficiency) : PowerPlant(name, efficiency)
    {
        readonly Type TypeFuel = typeof(Gas);
    }
}
