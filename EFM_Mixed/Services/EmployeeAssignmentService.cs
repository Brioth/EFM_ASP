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
    public class EmployeeAssignmentService : IEmployeeAssignmentService
    {
        private readonly IEmployeeAssignmentRepository _employeeAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeAssignmentService(IEmployeeAssignmentRepository employeeAssignmentRepository, IUnitOfWork unitOfWork)
        {
            _employeeAssignmentRepository = employeeAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeAssignment>> ListAsync()
        {
            return await _employeeAssignmentRepository.ListAsync();
        }

        public async Task<EmployeeAssignmentResponse> GetByIdAsync(int id)
        {
            var existingEmployeeAssignment = await _employeeAssignmentRepository.FindByIdAsync(id);

            if (existingEmployeeAssignment == null)
                return new EmployeeAssignmentResponse("EmployeeAssignment not found.");

            return new EmployeeAssignmentResponse(existingEmployeeAssignment);
        }

        public async Task<EmployeeAssignmentResponse> SaveAsync(EmployeeAssignment employeeAssignment)
        {
            try
            {               
                await _employeeAssignmentRepository.AddAsync(employeeAssignment);
                await _unitOfWork.CompleteAsync();

                return new EmployeeAssignmentResponse(employeeAssignment);
            }
            catch (Exception ex)
            {
                return new EmployeeAssignmentResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeAssignmentResponse> UpdateAsync(int id, EmployeeAssignment employeeAssignment)
        {
            var existingEmployeeAssignment = await _employeeAssignmentRepository.FindByIdAsync(id);

            if (existingEmployeeAssignment == null)
                return new EmployeeAssignmentResponse("EmployeeAssignment not found.");

            existingEmployeeAssignment.StartDate = employeeAssignment.StartDate != existingEmployeeAssignment.StartDate && employeeAssignment.StartDate != default(DateTime) ? employeeAssignment.StartDate : existingEmployeeAssignment.StartDate;
            existingEmployeeAssignment.EndDate = employeeAssignment.EndDate != existingEmployeeAssignment.EndDate && employeeAssignment.EndDate != default(DateTime) ? employeeAssignment.EndDate : existingEmployeeAssignment.EndDate;
            existingEmployeeAssignment.FTEPerWeek = employeeAssignment.FTEPerWeek != existingEmployeeAssignment.FTEPerWeek && employeeAssignment.FTEPerWeek != default(Double) ? employeeAssignment.FTEPerWeek : existingEmployeeAssignment.FTEPerWeek;

            try
            {
                _employeeAssignmentRepository.Update(existingEmployeeAssignment);
                await _unitOfWork.CompleteAsync();

                return new EmployeeAssignmentResponse(existingEmployeeAssignment);
            }
            catch (Exception ex)
            {
                return new EmployeeAssignmentResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<EmployeeAssignmentResponse> DeleteAsync(int id)
        {
            var existingEmployeeAssignment = await _employeeAssignmentRepository.FindByIdAsync(id);

            if (existingEmployeeAssignment == null)
                return new EmployeeAssignmentResponse("Employee Assignment not found.");

            try
            {
                _employeeAssignmentRepository.Remove(existingEmployeeAssignment);
                await _unitOfWork.CompleteAsync();

                return new EmployeeAssignmentResponse(existingEmployeeAssignment);
            }
            catch (Exception ex)
            {
                return new EmployeeAssignmentResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
