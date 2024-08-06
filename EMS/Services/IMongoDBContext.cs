
using EMS.DTOs;

namespace EMS.Services
{
    public interface IMongoDBContext<T> where T : class
    {
        Task Create(T entity);
        Task Delete(Guid id);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<List<T>> GetEmployeeByCountry(string country);
        Task<List<T>> GetEmployeeByDesignation(string designation);
        Task Update(Guid id, T entity);
        Task<List<T>> GetEmployeesByDepartment(string departmentName);
        Task<List<EmployeeLoginDTO>> GetEmployeeWithLoginDetails();
    }
}