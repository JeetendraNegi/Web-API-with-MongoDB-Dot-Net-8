using BL;

namespace EMS.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IMongoDBContext<Payroll> _context;

        public PayrollService(IMongoDBContext<Payroll> context)
        {
            _context = context;
        }

        public async Task Create(Payroll entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Create(entity);
        }

        public async Task Update(Guid id, Payroll entity)
        {
            await _context.Update(id, entity);
        }

        public async Task Delete(Guid id)
        {
            await _context.Delete(id);
        }

        public async Task<Payroll> Get(Guid id)
        {
            return await _context.Get(id);
        }

        public async Task<List<Payroll>> GetAll()
        {
            return await _context.GetAll();
        }
    }
}
