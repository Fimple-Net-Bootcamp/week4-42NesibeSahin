using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using EntityLayer.DTOs;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class KullaniciRepository:GenericRepository<Kullanici>,IKullaniciRepository
    {
		private readonly IMapper _mapper;
		public KullaniciRepository(ProjeDB context, IMapper mapper) : base(context)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<EvcilHayvanAktivitelerListDTO> KullaniciEvcilHayvanIstatistikAl(int kullaniciID)
		{
			List<int> evcilHayvanKullaniciID = await _context.EvcilHayvanlar.Where(x => x.KullaniciID == kullaniciID).Select(x => x.KullaniciID).ToListAsync();

			var aktvtLog = await _context.LogAktivite.Where(x => evcilHayvanKullaniciID.Contains(x.EvcilHayvanID)).ToListAsync();
			var beslenmeLog = await _context.LogBeslenme.Where(x => evcilHayvanKullaniciID.Contains(x.EvcilHayvanID)).ToListAsync();
			var saglikDurumLog = await _context.LogSaglik.Where(x => evcilHayvanKullaniciID.Contains(x.EvcilHayvanID)).ToListAsync();


			EvcilHayvanAktivitelerListDTO evcilHayvanAktivitelerListDTO = new EvcilHayvanAktivitelerListDTO()
			{
				LogAktivites = _mapper.Map<List<logAktivitelerDTO>>(aktvtLog),
				LogBeslenmes = _mapper.Map<List<LogBeslenmeDTO>>(beslenmeLog),
				LogSagliks = _mapper.Map<List<LogSaglikDurumlariDTO>>(saglikDurumLog)
			};
			return evcilHayvanAktivitelerListDTO;
		}
	}
}
