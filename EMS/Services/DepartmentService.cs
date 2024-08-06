using BL;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoDBContext<Department> _context;

        public DepartmentService(IMongoDBContext<Department> context)
        {
            _context = context;
        }

        public async Task Create(Department entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Create(entity);
        }

        public async Task Update(Guid id, Department entity)
        {
            await _context.Update(id, entity);
        }

        public async Task Delete(Guid id)
        {
            await _context.Delete(id);
        }

        public async Task<Department> Get(Guid id)
        {
            return await _context.Get(id);
        }

        public async Task<List<Department>> GetAll()
        {
            return await _context.GetAll();
        }
    }
}
