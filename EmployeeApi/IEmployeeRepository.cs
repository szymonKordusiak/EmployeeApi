using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployeeByFirstNameAndLastName(string firstName, string lastName);
        void DeleteEmployee(Employee employee);


    }
}
