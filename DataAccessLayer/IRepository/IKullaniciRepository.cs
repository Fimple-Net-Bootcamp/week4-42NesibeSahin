using EntityLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IKullaniciRepository : IGenericRepository<Kullanici>
    {
		Task<EvcilHayvanAktivitelerListDTO> KullaniciEvcilHayvanIstatistikAl(int kullaniciID);
	}
}
