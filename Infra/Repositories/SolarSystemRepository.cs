using Domain.Entities;
using Domain.Interfaces;
using Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class SolarSystemRepository : ISolarSystemRepository
    {
        private readonly SsDbContext _context;

        public SolarSystemRepository(SsDbContext context)
        {
            _context = context;
        }

        private static Func<SolarSystem, bool> SearchIntoSolarSystems(string search) =>
            g =>
                g.Name.ToLower().Contains(search.ToLower())
                || (g.Description != null && g.Description.ToLower().Contains(search.ToLower()));

        private static Func<Planet, bool> SearchIntoPlanets(Guid solarSystemId, string search) =>
            p =>
                p.SolarSystemId == solarSystemId
                && (
                    p.Name.ToLower().Contains(search.ToLower())
                    || (p.Description != null && p.Description.ToLower().Contains(search.ToLower()))
                    || p.Circumference.ToString().Contains(search.ToLower())
                    || p.Population.ToString().Contains(search.ToLower())
                );

        public IQueryable<SolarSystem> GetSolarSystems(string search = null) =>
            search == null
                ? _context.SolarSystem.Include(s => s.Planets)
                : _context.SolarSystem
                    .Include(s => s.Planets)
                    .Where(SearchIntoSolarSystems(search))
                    .AsQueryable();

        public SolarSystem GetSolarSystemById(Guid id) =>
            _context.SolarSystem.Include(s => s.Planets).FirstOrDefault(s => s.Id == id);

        public SolarSystem InsertSolarSystem(SolarSystem solarSystem)
        {
            if (!solarSystem.IsValid())
                throw new FormatException("Solar system missing required fields");

            _context.SolarSystem.Add(solarSystem);
            _context.SaveChanges();

            return solarSystem;
        }

        public SolarSystem UpdateSolarSystem(Guid id, SolarSystem solarSystem)
        {
            if (!solarSystem.IsValid())
                throw new FormatException("Solar system missing required fields");

            var oldSolarSystem = GetSolarSystemById(id);
            if (oldSolarSystem == null)
                throw new FormatException("Doesn't exist a solar system with the given Id");

            solarSystem.Id = id;
            oldSolarSystem = solarSystem;

            _context.SolarSystem.Update(solarSystem);
            _context.SaveChanges();

            return solarSystem;
        }

        public void DeleteSolarSystem(Guid id)
        {
            var solarSystem = GetSolarSystemById(id);
            if (solarSystem == null)
                return;

            _context.SolarSystem.Remove(solarSystem);
            _context.SaveChanges();
        }

        public IQueryable<Planet> GetPlanetsBySolarSystemId(Guid id, string search = null) =>
            _context.Planet
                .Where(search == null ? p => p.SolarSystemId == id : SearchIntoPlanets(id, search))
                .AsQueryable();

        public Planet InsertPlanet(Guid solarSystemId, Planet planet)
        {
            planet.SolarSystemId = solarSystemId;
            if (!planet.IsValid())
                throw new FormatException("Solar system missing required fields");

            _context.Planet.Add(planet);
            _context.SaveChanges();

            return planet;
        }

        public Planet UpdatePlanet(Guid solarSystemId, Guid planetId, Planet planet)
        {
            planet.Id = planetId;
            planet.SolarSystemId = solarSystemId;
            if (!planet.IsValid())
                throw new FormatException("Solar system missing required fields");

            _context.Planet.Update(planet);
            _context.SaveChanges();

            return planet;
        }

        public void DeletePlanets(Guid solarSystemId)
        {
            var planets = _context.Planet.Where(p => p.SolarSystemId == solarSystemId);
            if (planets.Count() == 0)
                return;

            _context.Planet.RemoveRange(planets);
            _context.SaveChanges();
        }

        public Planet GetPlanetBySolarSystemIdAndPlanetId(Guid solarSytemId, Guid planetId) =>
            _context.Planet.FirstOrDefault(
                p => p.Id == planetId && p.SolarSystemId == solarSytemId
            );

        public void DeletePlanet(Guid solarSystemId, Guid planetId)
        {
            var planet = GetPlanetBySolarSystemIdAndPlanetId(solarSystemId, planetId);
            if (planet == null)
                return;

            _context.Planet.Remove(planet);
            _context.SaveChanges();
        }
    }
}
