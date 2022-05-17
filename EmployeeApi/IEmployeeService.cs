using EmployeeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IEmployeeService
    {
        decimal GetMaxSalary();
        decimal GetMinSalary();
        decimal GetAvarageSalary();
        long GetNumberOfEmployees();
         Stats GetStats();
    }
}
