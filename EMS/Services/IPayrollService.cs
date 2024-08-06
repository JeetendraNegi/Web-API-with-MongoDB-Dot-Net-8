using BL;

namespace EMS.Services
{
    public interface IPayrollService
    {
        Task Create(Payroll entity);
        Task Delete(Guid id);
        Task<Payroll> Get(Guid id);
        Task<List<Payroll>> GetAll();
        Task Update(Guid id, Payroll entity);
    }
}