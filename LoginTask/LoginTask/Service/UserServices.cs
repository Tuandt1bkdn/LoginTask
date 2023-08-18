using LoginTask.Repositories;
using LoginTask.DBContext;
using LoginTask.Models;
using AutoMapper;

namespace LoginTask.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserClass>> GetAll();
        Task<UserClass> GetById(int id);
        /*Task Create(CreateRequest model);*/

    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserClass>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<UserClass> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new KeyNotFoundException("User not found");
            return user;
        }
        /*public async Task Create(CreateRequest model)
        {
            var user = _mapper.Map<UserClass>(model);
            await _userRepository.Create(user);
            
        }*/
    }
}
