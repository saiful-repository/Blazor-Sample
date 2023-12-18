using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _appDBContext;
        public DepartmentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            var result = await _appDBContext.Departments.FirstOrDefaultAsync(r => r.DepartmentId == departmentId);
            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _appDBContext.Departments.ToListAsync();
        }
    }
}
