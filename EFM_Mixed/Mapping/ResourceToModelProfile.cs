using AutoMapper;
using EFM_Mixed.Domain.Models;
using EFM_Mixed.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>()
                .ForMember(e => e.EmployeeAssignments, opt => opt.Ignore());
            CreateMap<SaveEmployeeAssignmentResource, EmployeeAssignment>();
            CreateMap<SaveAssignmentResource, Assignment>()
                .ForMember(a => a.EmployeeAssignments, opt => opt.Ignore());
        }
    }
}
