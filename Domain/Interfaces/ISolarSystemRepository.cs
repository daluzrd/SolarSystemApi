using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface ISolarSystemRepository
    {
        IQueryable<SolarSytem> Get(string search = null);
        SolarSytem GetById(int id);
        SolarSytem Insert(SolarSytem solarSystem);
        SolarSytem Update(SolarSytem solarSystem);
        void Delete(int id);
    }
}
