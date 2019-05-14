using EFM_Mixed.Domain.Models;
using EFM_Mixed.Domain.Repositories;
using EFM_Mixed.Domain.Services;
using EFM_Mixed.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentService(IAssignmentRepository assignmentRepository, IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Assignment>> ListAsync()
        {
            return await _assignmentRepository.ListAsync();
        }

        public async Task<AssignmentResponse> GetByIdAsync(int id)
        {
            var existingAssignment = await _assignmentRepository.FindByIdAsync(id);

            if (existingAssignment == null)
                return new AssignmentResponse("Employee not found.");

            return new AssignmentResponse(existingAssignment);
        }

        public async Task<AssignmentResponse> SaveAsync(Assignment assignment)
        {
            try
            {               
                await _assignmentRepository.AddAsync(assignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(assignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<AssignmentResponse> UpdateAsync(int id, Assignment assignment)
        {
            var existingAssignment = await _assignmentRepository.FindByIdAsync(id);

            if (existingAssignment == null)
                return new AssignmentResponse("Assignment not found.");


            existingAssignment.Name = assignment.Name ?? existingAssignment.Name;
            existingAssignment.Description = assignment.Description ?? existingAssignment.Description;
            existingAssignment.StartDate = assignment.StartDate!=existingAssignment.StartDate && assignment.StartDate != default(DateTime) ? assignment.StartDate : existingAssignment.StartDate;
            existingAssignment.EndDate = assignment.EndDate != existingAssignment.EndDate && assignment.EndDate != default(DateTime) ? assignment.EndDate : existingAssignment.EndDate;
            existingAssignment.FTEPerWeek = assignment.FTEPerWeek != existingAssignment.FTEPerWeek && assignment.FTEPerWeek != default(Double) ? assignment.FTEPerWeek : existingAssignment.FTEPerWeek;

            try
            {
                _assignmentRepository.Update(existingAssignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(existingAssignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<AssignmentResponse> DeleteAsync(int id)
        {
            var existingAssignment = await _assignmentRepository.FindByIdAsync(id);

            if (existingAssignment == null)
                return new AssignmentResponse("Employee not found.");

            try
            {
                _assignmentRepository.Remove(existingAssignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(existingAssignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
