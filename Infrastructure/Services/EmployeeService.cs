using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation
            };

            var newEmployee = await _employeeRepository.AddAsync(employee);
            var employeeModel = new EmployeeResponseModel
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
                Password = newEmployee.Password,
                Designation = newEmployee.Designation
            };
            return employeeModel;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployees()
        {
            var employee = await _employeeRepository.ListAllAsync();
            var employeeList = new List<EmployeeResponseModel>();
            foreach (var emp in employee)
            {
                employeeList.Add(new EmployeeResponseModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Password = emp.Password,
                    Designation = emp.Designation
                });
            }
            return employeeList;
        }

        public async Task<EmployeeResponseModel> GetEmployeeDetails(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeDetails = new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };
            return employeeDetails;
        }

        public async Task<EmployeeResponseModel> UpdateEmployee(int id, EmployeeRequestModel model)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            employee.Name = model.Name;
            employee.Password = model.Password;
            employee.Designation = model.Designation;

            var employeeDetails = new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };

            var updatedEmployee = await _employeeRepository.UpdateAsync(employee);
            return employeeDetails;
        }
    }
}
