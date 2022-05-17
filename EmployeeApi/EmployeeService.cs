using ConsoleApp4;
using EmployeeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        public decimal GetMaxSalary()
        {
            return repository.GetEmployees().Max(x => x.Salary);
        }
        public decimal GetMinSalary()
        {
            return repository.GetEmployees().Min(x => x.Salary);
        }
        public decimal GetAvarageSalary()
        {
            return repository.GetEmployees().Average(x => x.Salary);
        }
        public long GetNumberOfEmployees()
        {
            return repository.GetEmployees().LongCount();
        }

        public Stats GetStats()
        {
            var stats = new Stats();
            stats.MinSalary = GetMinSalary();
            stats.MaxSalary = GetMaxSalary(); 
            stats.AvarageSalary = GetAvarageSalary();
            stats.NumberOfEmployees = GetNumberOfEmployees();

            return stats;
        }

    }
}
