﻿using AutoMapper;
using EFM_Mixed.Domain.Models;
using EFM_Mixed.Domain.Services;
using EFM_Mixed.Extensions;
using EFM_Mixed.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAssignmentsController : ControllerBase
    {
        private readonly IEmployeeAssignmentService _employeeAssignmentService;
        private readonly IMapper _mapper;

        public EmployeeAssignmentsController(IEmployeeAssignmentService employeeAssignmentService, IMapper mapper)
        {
            _employeeAssignmentService = employeeAssignmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeAssignmentResource>> GetAllAsync()
        {
            var employeeAssignments = await _employeeAssignmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<EmployeeAssignment>, IEnumerable<EmployeeAssignmentResource>>(employeeAssignments);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _employeeAssignmentService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeAssignmentResource = _mapper.Map<EmployeeAssignment, EmployeeAssignmentResource>(result.EmployeeAssignment);
            return Ok(employeeAssignmentResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeAssignmentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var employeeAssignment = _mapper.Map<SaveEmployeeAssignmentResource, EmployeeAssignment>(resource);
            var result = await _employeeAssignmentService.SaveAsync(employeeAssignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeAssignmentResource = _mapper.Map<EmployeeAssignment, EmployeeAssignmentResource>(result.EmployeeAssignment);
            return Ok(employeeAssignmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployeeAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employeeAssignment = _mapper.Map<SaveEmployeeAssignmentResource, EmployeeAssignment>(resource);
            var result = await _employeeAssignmentService.UpdateAsync(id, employeeAssignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeAssignmentResource = _mapper.Map<EmployeeAssignment, SaveEmployeeAssignmentResource>(result.EmployeeAssignment);
            return Ok(employeeAssignmentResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeAssignmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<EmployeeAssignment, EmployeeAssignmentResource>(result.EmployeeAssignment);
            return Ok(assignmentResource);
        }
    }
}
