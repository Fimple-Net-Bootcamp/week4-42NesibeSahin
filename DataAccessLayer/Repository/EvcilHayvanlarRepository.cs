using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
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
    public class EvcilHayvanlarRepository : GenericRepository<EvcilHayvanlar>, IEvcilHayvanlarRepository
    {
		private readonly IMapper _mapper;
		public EvcilHayvanlarRepository(ProjeDB context, IMapper mapper) : base(context)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<EvcilHayvanAktivitelerListDTO> EvcilHayvanIstatistikAl(int evcilHayvanID)
		{
			var aktvtLog = await _context.LogAktivite.Where(x => x.EvcilHayvanID == evcilHayvanID).ToListAsync();
			var beslenmeLog = await _context.LogBeslenme.Where(x => x.EvcilHayvanID == evcilHayvanID).ToListAsync();
			var saglikDurumLog = await _context.LogSaglik.Where(x => x.EvcilHayvanID == evcilHayvanID).ToListAsync();

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
