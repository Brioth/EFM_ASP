using EFM_Mixed.Domain.Models;
using EFM_Mixed.Domain.Repositories;
using EFM_Mixed.Persistence.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Persistence.SQL.Repositories
{
    public class SQLAssignmentRepository : SQLBaseRepository, IAssignmentRepository
    {
        public SQLAssignmentRepository(SQLDbContext context) : base(context) { }

        public async Task AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
        }

        public async Task<Assignment> FindByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<IEnumerable<Assignment>> ListAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public void Remove(Assignment assignment)
        {
            _context.Assignments.Remove(assignment);
        }

        public void Update(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
        }
    }
}
