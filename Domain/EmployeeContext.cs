using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base(@"Data Source=DESKTOP-AMBDKC6;Database=CompanyEmployees;Integrated Security=sspi;")
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

    }
}
