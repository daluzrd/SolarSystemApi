using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IPlanetRepository : IRepository<Planet>
    {
        IQueryable<Planet> Get(string search = null);
    }
}