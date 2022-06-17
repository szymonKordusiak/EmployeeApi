using Domain;

namespace EmployeeApi.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        public Department DepartmentDto { get; set; }
    }
}
