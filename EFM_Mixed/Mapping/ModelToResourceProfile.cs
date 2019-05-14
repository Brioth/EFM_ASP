using AutoMapper;
using EFM_Mixed.Domain.Models;
using EFM_Mixed.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Mapping
{
    public class ModeltoResourceProfile : Profile
    {
        public ModeltoResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>();
            CreateMap<Assignment, AssignmentResource>();
            CreateMap<EmployeeAssignment, EmployeeAssignmentResource>();
        }
    }
}
