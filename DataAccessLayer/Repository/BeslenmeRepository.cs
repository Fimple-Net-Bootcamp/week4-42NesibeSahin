using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BeslenmeRepository : GenericRepository<Beslenme>, IBeslenmeRepository
    {
        private readonly IMapper _mapper;
        public BeslenmeRepository(ProjeDB context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<int> SaveChanges()
        {
            var degisiklikler = _context.ChangeTracker
            .Entries<Beslenme>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            int result = await base.SaveChanges();


            foreach (var degisiklik in degisiklikler)
            {
                Beslenme beslenme = degisiklik.Entity;
                LogBeslenme logBeslenme = _mapper.Map<LogBeslenme>(beslenme);
                logBeslenme.DegistirmeTarihi = DateTime.Now;

                _context.Set<LogBeslenme>().Add(logBeslenme);
            }

            if (degisiklikler.Any())
            {
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
