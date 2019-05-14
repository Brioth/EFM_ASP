using EFM_Mixed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<IEnumerable<Employee>> ListExtendedAsync();
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(int id);
        Task<Employee> FindByIdExtendedAsync(int id);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}
