using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq;

namespace Domain.Interfaces
{
    public interface ISolarSystemRepository : IRepository<SolarSystem>
    {
        IQueryable<SolarSystem> Get(string search = null);
    }
}