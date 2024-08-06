using BL;
using EMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAll()
        {
            return Ok(await _departmentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(Guid id)
        {
            return Ok(await _departmentService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Department department)
        {
            await _departmentService.Create(department);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Department department)
        {
            await _departmentService.Update(id, department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _departmentService.Delete(id);
            return Ok();
        }
    }
}
