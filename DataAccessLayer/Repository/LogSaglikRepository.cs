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
    public class LogSaglikRepository : GenericRepository<LogSaglik>, ILogSaglikRepository
    {
        public LogSaglikRepository(ProjeDB context) : base(context)
        {

        }

    }
}
