using BL;
using EMS.DTOs;

namespace EMS.Services
{
    public interface IEmployeeService
    {
        Task Create(Employee entity);
        Task Delete(Guid id);
        Task<Employee> Get(Guid id);
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetEmployeeByCountry(string country);
        Task<List<Employee>> GetEmployeeByDesignation(string designation);
        Task Update(Guid id, Employee entity);
        Task<List<Employee>> GetEmployeesByDepartment(string departmentName);
        Task<List<EmployeeLoginDTO>> GetEmployeeWithLoginDetails();
    }
}