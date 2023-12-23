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
    public class AktivitelerRepository : GenericRepository<Aktiviteler>, IAktivitelerRepository
    {
        private readonly IMapper _mapper;
        public AktivitelerRepository(ProjeDB context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

      
        public override async Task<int> SaveChanges()
        {
            var degisiklikler = _context.ChangeTracker
            .Entries<Aktiviteler>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            int result = await base.SaveChanges();


            foreach (var degisiklik in degisiklikler)
            {
                Aktiviteler aktivite = degisiklik.Entity;
                LogAktivite logAktivite = _mapper.Map<LogAktivite>(aktivite);

                _context.Set<LogAktivite>().Add(logAktivite);
            }

            if (degisiklikler.Any())
            {
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
