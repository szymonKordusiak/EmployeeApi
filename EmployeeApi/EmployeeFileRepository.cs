using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class EmployeeFileRepository : IEmployeeRepository
    {
        private static readonly string fileName = "Plik.txt";

        public void AddEmployee(Employee employee)
        {

            using (var sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine($"{employee.EmployeeID};{employee.FirstName};{employee.LastName};{employee.Salary}");


            }
        }

        public void DeleteEmployee(Employee employee)
        {
            var employees = GetEmployees();

            var employeeToRemove = employees.Where(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName).FirstOrDefault();

            employees.Remove(employeeToRemove);



            using (var sw = new StreamWriter(fileName, false))
            {
                foreach (Employee emp in employees)
                {
                    sw.WriteLine($"{emp.EmployeeID};{emp.FirstName};{emp.LastName};{emp.Salary}");
                }
            }


            Console.WriteLine("Usunięto pomyślnie pracownika");
            Console.WriteLine();

        }

        public Employee GetEmployeeByFirstNameAndLastName(string firstName, string lastName)
        {

            return this.GetEmployees().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var sr = new StreamReader(fileName))
            {


                while (!sr.EndOfStream)
                {


                    string line = sr.ReadLine();

                    string[] parts = line.Split(';');

                    Employee employee = new Employee();
                    employee.EmployeeID = int.Parse(parts[0]);
                    employee.FirstName = parts[1];
                    employee.LastName = parts[2];
                    employee.Salary = decimal.Parse(parts[3]);

                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
