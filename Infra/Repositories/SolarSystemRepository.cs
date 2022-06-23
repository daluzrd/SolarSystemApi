using Domain.Entities;
using Domain.Interfaces;
using Infra.DatabaseContext;
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

        private Func<SolarSytem, bool> Search(string search) => g => g.Name.ToLower().Contains(search.ToLower())
                                                                 || (g.Description != null
                                                                    && g.Description.ToLower().Contains(search.ToLower()));

        public IQueryable<SolarSytem> Get(string search = null)
        {
            if (string.IsNullOrEmpty(search)) return _context.SolarSytem;

            return _context.SolarSytem.Where(Search(search)).AsQueryable();
        }

        public SolarSytem GetById(int id) => _context.SolarSytem.FirstOrDefault(g => g.Id == id);

        public SolarSytem Insert(SolarSytem solarSytem)
        {
            if (solarSytem.IsValid())
            {
                _context.SolarSytem.Add(solarSytem);
                _context.SaveChanges();

                return solarSytem;
            }

            throw new FormatException("Solar system missing required fields");
        }

        public SolarSytem Update(SolarSytem solarSytem)
        {
            if (solarSytem.IsValid())
            {
                _context.SolarSytem.Update(solarSytem);
                _context.SaveChanges();

                return solarSytem;
            }

            throw new FormatException("Solar system missing required fields");
        }

        public void Delete(int id)
        {
            var solarSytem = GetById(id);
            if (solarSytem == null) return;

            _context.SolarSytem.Remove(solarSytem);
            _context.SaveChanges();
        }
    }
}
