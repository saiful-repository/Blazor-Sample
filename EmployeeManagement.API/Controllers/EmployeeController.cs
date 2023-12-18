using EmployeeManagement.API.Model;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var result = await employeeRepository.GetEmployees();
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an server error");
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if(result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an server error");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {                
                if (employee == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdEmployee = await employeeRepository.AddEmployee(employee);
                    return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an server error");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeUpdate = await employeeRepository.GetEmployee(employee.EmployeeId);
                if (employeeUpdate == null)
                {
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");
                }
                return await employeeRepository.UpdateEmployee(employee);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an server error");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeDelete = await employeeRepository.GetEmployee(id);
                if (employeeDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

               return await employeeRepository.DeleteEmployee(id);               

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an server error");
            }

        }
    }
}
