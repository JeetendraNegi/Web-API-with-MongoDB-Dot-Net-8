using BL;

namespace EMS.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMongoDBContext<Login> _context;

        public LoginService(IMongoDBContext<Login> context)
        {
            _context = context;
        }

        public async Task Create(Login entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Create(entity);
        }

        public async Task Update(Guid id, Login entity)
        {
            await _context.Update(id, entity);
        }

        public async Task Delete(Guid id)
        {
            await _context.Delete(id);
        }

        public async Task<Login> Get(Guid id)
        {
            return await _context.Get(id);
        }

        public async Task<List<Login>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<Login> GetByUserName(string Username)
        {
            var loginUsers = await _context.GetAll();
           return loginUsers.Find(x => x.Username == Username);
        }
    }
}
