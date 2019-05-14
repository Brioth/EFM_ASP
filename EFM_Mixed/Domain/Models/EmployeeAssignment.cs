using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Models
{
    public class EmployeeAssignment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double FTEPerWeek { get; set; }
    }
}
