using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Model
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { 
        
        }

        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Department data
            modelBuilder.Entity<Department>().HasData(new Department
            {
               DepartmentId = 1,
               DepartmentName= "IT"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 2,
                DepartmentName = "HR"
            });

            //Seed Employee data
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john@gmail.com",
                DateOfBirth = new System.DateTime(1980, 9, 29),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"

            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "mary",
                LastName = "kendis",
                Email = "mary@gmail.com",
                DateOfBirth = new System.DateTime(1980, 9, 29),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png"

            });           
        }

    }
}
