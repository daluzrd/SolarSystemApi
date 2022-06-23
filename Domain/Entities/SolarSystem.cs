using Domain.Generics;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SolarSystem : BaseModel
    {
        public virtual IList<Planet> Planets { get; set; }

        public override bool IsValid() => Name != null;
    }
}