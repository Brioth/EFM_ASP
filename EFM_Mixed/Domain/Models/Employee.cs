using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<EmployeeAssignment> EmployeeAssignments { get; set; } = new List<EmployeeAssignment>();
    }
}
