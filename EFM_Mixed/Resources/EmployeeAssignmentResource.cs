using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Resources
{
    public class EmployeeAssignmentResource
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string AssignmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double FTEPerWeek { get; set; }


    }
}
