using Domain.Entities;
using Domain.Interfaces;
using Infra.DatabaseContext;
using Infra.Repositories.Generics;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        private readonly SsDbContext _context;

        public PlanetRepository(SsDbContext context) : base(context)
        {
            _context = context;
        }

        private static Func<Planet, bool> Search(string search) => p => p.Name.ToLower().Contains(search.ToLower())
                                                                 || (p.Description != null
                                                                    && p.Description.ToLower().Contains(search.ToLower()))
                                                                 || p.Circumference.ToString().Contains(search.ToLower())
                                                                 || p.Population.ToString().Contains(search.ToLower());

        public IQueryable<Planet> Get(string search = null) =>
            base.Get(search != null ? Search(search) : s => true);
    }
}