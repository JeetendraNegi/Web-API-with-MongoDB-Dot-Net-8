using BL;
using EMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(Guid id)
        {
            return Ok(await _employeeService.Get(id));
        }

        [HttpGet("GetEmployee/{country}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeByCountry(string country)
        {
            return Ok(await _employeeService.GetEmployeeByCountry(country));
        }

        [HttpGet("GetEmployee/{designation}/Designation")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeByDesignation(string designation)
        {
            return Ok(await _employeeService.GetEmployeeByDesignation(designation));
        }

        [HttpGet("GetEmployees/{departmentName}/Department")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByDepartment(string departmentName)
        {
            return Ok(await _employeeService.GetEmployeesByDepartment(departmentName));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            await _employeeService.Create(employee);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Employee employee)
        {
            await _employeeService.Update(id, employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }

        [HttpGet("GetEmployeeWithLoginDetails")]
        public async Task<ActionResult> GetEmployeeWithLoginDetails()
        {
            return Ok(await _employeeService.GetEmployeeWithLoginDetails());
        }
    }
}
