using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.ValueObjects.Fuels
{
    public class GasTests
    {
        public void GivenNegativeValueWhenInitGasThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Gas(-8));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(4242)]
        public void GivenPositiveValueWhenInitGasThenGasValueShouldBeEqualToTheParameter(int value)
        {
            var gas = new Gas(value);

            Assert.Equal(value, gas.Value);
        }
    }
}
