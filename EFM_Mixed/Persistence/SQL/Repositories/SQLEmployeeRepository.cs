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
    public class SQLEmployeeRepository : SQLBaseRepository, IEmployeeRepository
    {
        public SQLEmployeeRepository(SQLDbContext context) : base(context) { }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employees
                            .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> ListExtendedAsync()
        {
            return await _context.Employees
                            .Include(e => e.EmployeeAssignments)
                            .ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _context.Employees
                            .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Employee> FindByIdExtendedAsync(int id)
        {
            return await _context.Employees
                            .Include(e => e.EmployeeAssignments)
                            .FirstOrDefaultAsync(e => e.Id == id);
        }
        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}
