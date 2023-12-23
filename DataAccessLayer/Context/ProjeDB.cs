using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccessLayer.Context
{
	public class ProjeDB:DbContext
	{

        public ProjeDB()
        {

        }

        public ProjeDB(DbContextOptions<ProjeDB> options) : base(options)
		{

		}
        public DbSet<Aktiviteler> Aktiviteler { get; set; }
        public DbSet<Besinler> Besinler { get; set; }
        public DbSet<EvcilHayvanlar> EvcilHayvanlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SaglikDurumlari> SaglikDurumlari { get; set; }
        public DbSet<Egitimler> Egitimler { get; set; }
        public DbSet<SosyalEtkilesimler> SosyalEtkilesimler { get; set; }
        public DbSet<Etkinlikler> Etkinlikler { get; set; }
        public DbSet<Beslenme> Beslenme { get; set; }
        public DbSet<LogAktivite> LogAktivite { get; set; }
        public DbSet<LogBeslenme> LogBeslenme { get; set; }
        public DbSet<LogSaglik> LogSaglik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
