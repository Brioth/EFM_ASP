using EFM_Mixed.Persistence.SQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Persistence.SQL.Repositories
{
    public abstract class SQLBaseRepository
    {
        protected readonly SQLDbContext _context;

        public SQLBaseRepository(SQLDbContext context)
        {
            _context = context;
        }
    }
}
