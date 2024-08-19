﻿using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace DomainTests.DomainServices
{
    public class PowerPlantServiceTests
    {
        [Fact]
        public void GivenPayLoad3WhenPowerPlantServiceGetMeritOrderThenReturnResponse3()
        {
            var load = new Load(new PositiveIntValue(910));
            var fuels = new List<Fuel>() 
            {
                new Gas(new PositiveDoubleValue(13.4))
            };

//            {
//                "load": 910,

//  "fuels":
//  {
//                    "gas(euro/MWh)": 13.4,
//    "kerosine(euro/MWh)": 50.8,
//    "co2(euro/ton)": 20,
//    "wind(%)": 60
//  },

//  "powerplants": [
//    {
//                    "name": "gasfiredbig1",
//      "type": "gasfired",
//      "efficiency": 0.53,
//      "pmin": 100,
//      "pmax": 460
//    },
//    {
//                    "name": "gasfiredbig2",
//      "type": "gasfired",
//      "efficiency": 0.53,
//      "pmin": 100,
//      "pmax": 460
//    },
//    {
//                    "name": "gasfiredsomewhatsmaller",
//      "type": "gasfired",
//      "efficiency": 0.37,
//      "pmin": 40,
//      "pmax": 210
//    },
//    {
//                    "name": "tj1",
//      "type": "turbojet",
//      "efficiency": 0.3,
//      "pmin": 0,
//      "pmax": 16
//    },
//    {
//                    "name": "windpark1",
//      "type": "windturbine",
//      "efficiency": 1,
//      "pmin": 0,
//      "pmax": 150
//    },
//    {
//                    "name": "windpark2",
//      "type": "windturbine",
//      "efficiency": 1,
//      "pmin": 0,
//      "pmax": 36
//    }
//  ]
//}
        }

    }
}
