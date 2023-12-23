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
    public class SaglikDurumlariRepository : GenericRepository<SaglikDurumlari>, ISaglikDurumlariRepository
    {
        private readonly IMapper _mapper;
        public SaglikDurumlariRepository(ProjeDB context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<int> SaveChanges()
        {
            var degisiklikler = _context.ChangeTracker
            .Entries<SaglikDurumlari>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            int result = await base.SaveChanges();


            foreach (var degisiklik in degisiklikler)
            {
                SaglikDurumlari saglikDurumlari = degisiklik.Entity;
                LogSaglik logSaglik = _mapper.Map<LogSaglik>(saglikDurumlari);
                logSaglik.Tarih = DateTime.Now;

                _context.Set<LogSaglik>().Add(logSaglik);
            }

            if (degisiklikler.Any())
            {
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
