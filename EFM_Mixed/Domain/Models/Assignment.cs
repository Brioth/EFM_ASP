using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double FTEPerWeek { get; set; }
        public IList<EmployeeAssignment> EmployeeAssignments { get; set; } = new List<EmployeeAssignment>();

    }
}
