using System.Security.Cryptography.X509Certificates;

namespace Domain.ValueObjects.Fuels
{
    public class Gas(PositiveValue value) : Fuel
    {
        public override string Name => "Gas";

        public override double Value { get; } = value.Value;
    }
}
