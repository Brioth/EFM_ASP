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
    public class SQLEmployeeAssignmentRepository : SQLBaseRepository, IEmployeeAssignmentRepository
    {
        public SQLEmployeeAssignmentRepository(SQLDbContext context) : base(context) { }

        public async Task AddAsync(EmployeeAssignment employeeAssignment)
        {
            await _context.EmployeeAssignments.AddAsync(employeeAssignment);
        }

        public async Task<EmployeeAssignment> FindByIdAsync(int id)
        {
            return await _context.EmployeeAssignments.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeeAssignment>> ListAsync()
        {
            return await _context.EmployeeAssignments.ToListAsync();
        }

        public void Remove(EmployeeAssignment employeeAssignment)
        {
            _context.EmployeeAssignments.Remove(employeeAssignment);
        }

        public void Update(EmployeeAssignment employeeAssignment)
        {
            _context.EmployeeAssignments.Update(employeeAssignment);
        }
    }
}
