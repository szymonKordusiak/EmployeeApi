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
                if(employee.Departments.DepartmentID > 0)
                {
                    if( context.Departments.Any(x => x.DepartmentID == employee.Departments.DepartmentID) )
                    {
                        employee.Departments = context.Departments.FirstOrDefault(x => x.DepartmentID == employee.Departments.DepartmentID);
                    }
                }
                context.Employees.Add(employee);
                context.SaveChanges();

            }
        }

        public void DeleteEmployee(Employee employee)
        {

            using (var context = new EmployeeContext())
            {
                var employeeDB = context.Employees.FirstOrDefault(emp => emp.Id == employee.Id);

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
                                

            return context.Employees.Include(x => x.Departments).ToList();
            }
        }

       
    }
}
