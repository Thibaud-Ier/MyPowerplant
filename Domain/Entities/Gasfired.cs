using Domain.ValueObjects.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gasfired(string name) : PowerPlant(name)
    {
        readonly Type TypeFuel = typeof(Gas);

        //        type: gasfired, turbojet or windturbine.

    }
}
