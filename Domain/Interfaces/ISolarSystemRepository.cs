using Domain.Entities;
using System;
using System.Linq;

namespace Domain.Interfaces
{
    public interface ISolarSystemRepository
    {
        IQueryable<SolarSystem> GetSolarSystems(string search = null);

        SolarSystem GetSolarSystemById(Guid id);

        SolarSystem InsertSolarSystem(SolarSystem solarSystem);

        SolarSystem UpdateSolarSystem(Guid id, SolarSystem solarSystem);

        void DeleteSolarSystem(Guid id);
        IQueryable<Planet> GetPlanetsBySolarSystemId(Guid id, string search = null);

        Planet InsertPlanet(Guid solarSystemId, Planet entity);

        Planet UpdatePlanet(Guid solarSystemId, Guid planetId, Planet entity);

        void DeletePlanets(Guid solarSystemId);

        Planet GetPlanetBySolarSystemIdAndPlanetId(Guid solarSytemId, Guid planetId);

        void DeletePlanet(Guid solarSystemId, Guid planetId);
    }
}
