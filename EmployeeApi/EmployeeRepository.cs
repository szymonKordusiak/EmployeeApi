using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeByFirstNameAndLastName(string firstName, string lastName)
        {
            return employees.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
            Console.WriteLine("Usunięto pomyślnie pracownika");
            Console.WriteLine();
        }

        

    }
}
