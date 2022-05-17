using ConsoleApp4;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeApi.Controllers
{
    [ApiController]
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
        
        
    }
}
