using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ServiceExtDAL
    {
        public static void AddDALSubService(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddScoped<IAktivitelerRepository, AktivitelerRepository>();
            service.AddScoped<IBesinlerRepository, BesinlerRepository>();
            service.AddScoped<IBeslenmeRepository, BeslenmeRepository>();
            service.AddScoped<IEgitimlerRepository, EgitimlerRepository>();
            service.AddScoped<IEtkinliklerRepository, EtkinliklerRepository>();
            service.AddScoped<IEvcilHayvanlarRepository, EvcilHayvanlarRepository>();
            service.AddScoped<IKullaniciRepository, KullaniciRepository>();
            service.AddScoped<ILogAktiviteRepository, LogAktiviteRepository>();
            service.AddScoped<ILogBeslenmeRepository, LogBeslenmeRepository>();
            service.AddScoped<ILogSaglikRepository, LogSaglikRepository>();
            service.AddScoped<ISaglikDurumlariRepository, SaglikDurumlariRepository>();
            service.AddScoped<ISosyalEtkilesimlerRepository, SosyalEtkilesimlerRepository>();


            service.AddDbContext<ProjeDB>(DbContextOptions => DbContextOptions.UseSqlite(configuration.GetConnectionString("ProjeDBConnectionString")));

        }


    }
}
