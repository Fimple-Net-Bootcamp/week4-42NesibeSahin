using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class LogAktiviteRepository : GenericRepository<LogAktivite>, ILogAktiviteRepository
    {
        public LogAktiviteRepository(ProjeDB context) : base(context)
        {

        }
    }
}
