using BL;

namespace EMS.Services
{
    public interface IDepartmentService
    {
        Task Create(Department entity);
        Task Delete(Guid id);
        Task<Department> Get(Guid id);
        Task<List<Department>> GetAll();
        Task Update(Guid id, Department entity);
    }
}