using BL;

namespace EMS.Services
{
    public interface ILoginService
    {
        Task Create(Login entity);
        Task Delete(Guid id);
        Task<Login> Get(Guid id);
        Task<List<Login>> GetAll();
        Task<Login> GetByUserName(string Username);
        Task Update(Guid id, Login entity);
    }
}