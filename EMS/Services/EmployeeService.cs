
using BL;
using EMS.DTOs;
using MongoDB.Driver;

namespace EMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoDBContext<Employee> _context;

        public EmployeeService(IMongoDBContext<Employee> context)
        {
            _context = context;
        }
        public Task Create(Employee entity)
        {
            entity.Id = Guid.NewGuid();
            return _context.Create(entity);
        }

        public Task Delete(Guid id)
        {
            return _context.Delete(id);
        }

        public Task<Employee> Get(Guid id)
        {
            return _context.Get(id);
        }

        public Task<List<Employee>> GetAll()
        {
            return _context.GetAll();
        }

        public Task<List<Employee>> GetEmployeeByCountry(string country)
        {
            return _context.GetEmployeeByCountry(country);
        }

        public Task<List<Employee>> GetEmployeeByDesignation(string designation)
        {
            return _context.GetEmployeeByDesignation(designation);
        }

        public Task Update(Guid id, Employee entity)
        {
            return _context.Update(id, entity);
        }

        public Task<List<Employee>> GetEmployeesByDepartment(string departmentName)
        {
            return _context.GetEmployeesByDepartment(departmentName);
        }

        public Task<List<EmployeeLoginDTO>> GetEmployeeWithLoginDetails()
        {
            return _context.GetEmployeeWithLoginDetails();
        }
    }
}
