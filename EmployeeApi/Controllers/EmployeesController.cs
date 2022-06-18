using ConsoleApp4;
using Domain;
using EmployeeApi.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IEmployeeService _employeeService;

        

        public EmployeesController()
        {
            
            _employeeRepository = new EmployeeDBRepository();
            _employeeService = new EmployeeService(_employeeRepository);
        }
        [HttpGet]

        public IEnumerable<EmployeeDto> Get()
        {

            var queries = _employeeRepository.GetEmployees();

            return queries.Select(x => new EmployeeDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Salary = x.Salary,
                DepartmentDto = new DepartmentDto()
                {
                    Id = x.DepartmentID,
                    Address = x.Departments.Address,
                    Name = x.Departments.Name,
                }
            } );
        }

        [HttpGet]
        [Route("stats")]
        public Stats GetStats()
        {
            return _employeeService.GetStats();
        }
        
        [HttpPost]
        [Route("addEmployee")]
        public void AddEmployee(EmployeeDto employee)
        {
            Employee employee1 = new Employee();

            employee1.FirstName = employee.FirstName;
            employee1.LastName = employee.LastName;
            employee1.Salary = employee.Salary;

            employee1.Departments = new Department()
            {
                DepartmentID = employee.DepartmentDto.Id,
                Address = employee.DepartmentDto.Address,
                Name = employee.DepartmentDto.Name,
            };
            


            _employeeRepository.AddEmployee(employee1);
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public IActionResult DeleteEmployee(string firstName, string lastName)
        {
            Employee employee = _employeeRepository.GetEmployeeByFirstNameAndLastName(firstName, lastName);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _employeeRepository.DeleteEmployee(employee);
                return Ok();
            }

            
        }

        [HttpPut]
        [Route("replaceEmployee ")]

        public IActionResult ReplaceEmployee(EmployeeDto employee, string firstName, string lastName)
        {
            Employee employeeToEdit = _employeeRepository.GetEmployeeByFirstNameAndLastName(firstName, lastName);

            if (employeeToEdit == null)
            {
                return NotFound();
            }
            else
            {
                _employeeRepository.DeleteEmployee(employeeToEdit);


                employeeToEdit.FirstName = employee.FirstName;
                employeeToEdit.LastName = employee.LastName;
                employeeToEdit.Salary = employee.Salary;

                _employeeRepository.AddEmployee(employeeToEdit);

                return Ok();
            }


        }
        
    }
}
