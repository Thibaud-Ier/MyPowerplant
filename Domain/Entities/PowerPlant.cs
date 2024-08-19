using Domain.Common;

namespace Domain.Entities
{
    public class PowerPlant : Entity
    {
        public override string Id => Name;

        public string Name { get; }

        public PowerPlant(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(nameof(name));
                
            Name = name;    
        }
    }
}
