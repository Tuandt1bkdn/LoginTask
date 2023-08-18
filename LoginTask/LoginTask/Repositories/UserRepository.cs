using Dapper;
using LoginTask.DBContext;
using Microsoft.Data.SqlClient;

namespace LoginTask.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserClass>> GetAll();
        Task<UserClass> GetById(int id);
        /*Task Create(UserClass user);*/
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
        /*public async Task Create(UserClass user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var sql = "INSERT INTO UserInfo(UserId, Name, Birthday, Email, Location, UserName, PasswordHash) VALUES (@UserId, @Name, @Birthday, @Email, @Location, @UserName, @PasswordHash)";
            await connection.ExecuteAsync(sql, user);
        }*/
    }
}
