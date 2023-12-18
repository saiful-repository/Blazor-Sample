using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Model
{
    public class EmploymentRepository:IEmployeeRepository
    {        
        private readonly AppDBContext _appDBContext;
        public EmploymentRepository(AppDBContext appDBContext) {
            _appDBContext = appDBContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _appDBContext.Employees.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await _appDBContext.Employees.FirstOrDefaultAsync(r => r.EmployeeId == employeeId);
            if (result != null)
            {
                _appDBContext.Employees.Remove(result);
                await _appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _appDBContext.Employees
                .Include(r=>r.Department)                
                .FirstOrDefaultAsync(r => r.EmployeeId == employeeId);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           return await _appDBContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _appDBContext.Employees.FirstOrDefaultAsync(r => r.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName=employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender=employee.Gender;
                result.PhotoPath=employee.PhotoPath;
                result.DepartmentId = employee.DepartmentId;
                await _appDBContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
