using EFM_Mixed.Domain.Repositories;
using EFM_Mixed.Persistence.SQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Persistence.SQL.Repositories
{
    public class SQLUnitOfWork : IUnitOfWork
    {
        private readonly SQLDbContext _context;

        public SQLUnitOfWork(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
