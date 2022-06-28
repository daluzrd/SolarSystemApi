using System;
using Domain.Generics;

namespace Domain.Entities
{
    public class Planet : BaseModel
    {
        public bool HasLife { get; set; }
        public double Circumference { get; set; }
        public int Population { get; set; }
        public Guid SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public override bool IsValid() => Name != null;
    }
}
