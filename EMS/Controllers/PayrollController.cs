using BL;
using EMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payroll>>> GetAll()
        {
            return Ok(await _payrollService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payroll>> Get(Guid id)
        {
            return Ok(await _payrollService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Payroll payroll)
        {
            await _payrollService.Create(payroll);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Payroll payroll)
        {
            await _payrollService.Update(id, payroll);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _payrollService.Delete(id);
            return Ok();
        }
    }
}
