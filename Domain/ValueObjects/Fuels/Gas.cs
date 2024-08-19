using System.Security.Cryptography.X509Certificates;

namespace Domain.ValueObjects.Fuels
{
    public class Gas : Fuel
    {
        public override string Name => "Gas";

        public override double Value { get; }

        public Gas(int value)
        {
            if (value < 0)
                throw new InvalidOperationException();

            Value = value;
        }
    }
}
