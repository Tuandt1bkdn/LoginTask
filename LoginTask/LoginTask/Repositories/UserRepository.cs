using Dapper;
using LoginTask.DBContext;
using Microsoft.Data.SqlClient;

namespace LoginTask.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserClass>> GetAll();
        Task<UserClass> GetById(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
       private DataContext _context;
        public UserRepository(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
        }
        
        public async Task<IEnumerable<UserClass>> GetAll()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var sql = " SELECT * FROM UserInfo ";
            return await connection.QueryAsync<UserClass>(sql);
        }
        public async Task<UserClass> GetById(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var sql = "SELECT * FROM UserInfo WHERE UserId = @id";
            return await connection.QuerySingleOrDefaultAsync<UserClass>(sql, new { id });
        }
    }
}
