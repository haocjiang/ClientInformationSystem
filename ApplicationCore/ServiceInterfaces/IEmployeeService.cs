using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> GetEmployeeDetails(int id);
        Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model);
        Task<EmployeeResponseModel> UpdateEmployee(int id, EmployeeRequestModel model);
        Task DeleteEmployee(int id);
    }
}
