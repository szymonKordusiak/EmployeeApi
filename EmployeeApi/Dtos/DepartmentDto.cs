using System.Collections.Generic;

namespace EmployeeApi.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentDtoID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<EmployeeDto> Employees { get; set; }
    }
}
