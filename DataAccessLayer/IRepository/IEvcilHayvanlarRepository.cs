using EntityLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IEvcilHayvanlarRepository : IGenericRepository<EvcilHayvanlar>
    {
		Task<EvcilHayvanAktivitelerListDTO> EvcilHayvanIstatistikAl(int evcilHayvanID);
	}
}
