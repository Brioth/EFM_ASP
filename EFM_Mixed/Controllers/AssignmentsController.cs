using AutoMapper;
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
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public AssignmentsController(IAssignmentService assignmentService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AssignmentResource>> GetAllAsync()
        {
            var assignments = await _assignmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentResource>>(assignments);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _assignmentService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Assignment);
            return Ok(assignmentResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.SaveAsync(assignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Assignment);
            return Ok(assignmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.UpdateAsync(id, assignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, SaveAssignmentResource>(result.Assignment);
            return Ok(assignmentResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _assignmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Assignment);
            return Ok(assignmentResource);
        }
    }
}
