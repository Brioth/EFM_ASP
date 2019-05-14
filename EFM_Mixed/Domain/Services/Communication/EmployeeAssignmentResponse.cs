using EFM_Mixed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Domain.Services.Communication
{
    public class EmployeeAssignmentResponse : BaseResponse
    {
        public EmployeeAssignment EmployeeAssignment { get; set; }

        private EmployeeAssignmentResponse(bool success, string message, EmployeeAssignment employeeAssignment) : base(success, message)
        {
            EmployeeAssignment = employeeAssignment;
        }

        public EmployeeAssignmentResponse(EmployeeAssignment employeeAssignment) : this(true, string.Empty, employeeAssignment) { }

        public EmployeeAssignmentResponse(string message) : this(false, message, null) { }


    }
}
