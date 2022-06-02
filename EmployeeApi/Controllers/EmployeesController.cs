using ConsoleApp4;
using EmployeeApi.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

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
            
            _employeeRepository = new EmployeeFileRepository();
            _employeeService = new EmployeeService(_employeeRepository);
        }
        [HttpGet]

        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetEmployees();
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
