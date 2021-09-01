using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employee = await _employeeService.GetAllEmployees();
            if (!employee.Any())
            {
                return NotFound("No employee Found");
            }
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var employee = await _employeeService.GetEmployeeDetails(id);
            if (employee == null)
            {
                return NotFound("No employee Found");
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel model)
        {
            var employee = await _employeeService.AddEmployee(model);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromBody] int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequestModel model)
        {
            await _employeeService.UpdateEmployee(id, model);
            return Ok();
        }
    }
}
