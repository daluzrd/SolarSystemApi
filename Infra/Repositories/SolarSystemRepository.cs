using Domain.Entities;
using Domain.Interfaces;
using Infra.DatabaseContext;
using Infra.Repositories.Generics;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class SolarSystemRepository : Repository<SolarSystem>, ISolarSystemRepository
    {
        private readonly SsDbContext _context;

        public SolarSystemRepository(SsDbContext context) : base(context)
        {
            _context = context;
        }

        private static Func<SolarSystem, bool> Search(string search) => g => g.Name.ToLower().Contains(search.ToLower())
                                                                 || (g.Description != null
                                                                    && g.Description.ToLower().Contains(search.ToLower()));

        public IQueryable<SolarSystem> Get(string search = null) =>
            base.Get(search != null ? Search(search) : s => true);
    }
}