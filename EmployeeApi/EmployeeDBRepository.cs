using ConsoleApp4;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EmployeeApi.Dtos;

namespace EmployeeApi
{
    public class EmployeeDBRepository : IEmployeeRepository
    {
        public void AddEmployee(Employee employee)
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();

            }
        }

        public void DeleteEmployee(Employee employee)
        {

            using (var context = new EmployeeContext())
            {
                var employeeDB = context.Employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);

                context.Employees.Remove(employeeDB);
                context.SaveChanges();

            }
        }
        public Employee GetEmployeeByFirstNameAndLastName(string firstName, string lastName)
        {
            using (var context = new EmployeeContext())
            {
                var employeeDB = context.Employees.FirstOrDefault(emp => emp.FirstName == firstName && emp.LastName == lastName);

                return employeeDB;

            }
        }

        public List<Employee> GetEmployees()
        {
            
            using (var context = new EmployeeContext())
            {
                
                var query = (from emp in context.Employees select new EmployeeDto
                {
                    EmployeeID = emp.EmployeeID,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary,

                }).ToList().Select(x => new Employee
                { 
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName, 
                    LastName = x.LastName, 
                    Salary = x.Salary,
                    Departments = new Department()
                    {
                        DepartmentID = x.DepartmentID,
                        
                    }
                }).ToList();

            return query;
            }
        }

       
    }
}
