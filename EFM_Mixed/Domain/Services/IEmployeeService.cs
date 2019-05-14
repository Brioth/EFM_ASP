using EFM_Mixed.Domain.Models;
using EFM_Mixed.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<IEnumerable<Employee>> ListExtendedAsync();
        Task<EmployeeResponse> GetByIdAsync(int id);
        Task<EmployeeResponse> GetByIdExtendedAsync(int id);
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(int id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(int id);
    }
}
