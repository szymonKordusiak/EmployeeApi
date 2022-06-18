using Domain;

namespace EmployeeApi.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DepartmentDto DepartmentDto { get; set; }
    }
}
