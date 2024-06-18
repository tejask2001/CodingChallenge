using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTO;

namespace CodingChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepository;

        public UserService(IRepository<int, User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            var users = await _userRepository.GetAsync();
            var user = users.FirstOrDefault(e => e.UserName == loginDTO.Username && e.Password == loginDTO.Password);

            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> RemoveUser(int id)
        {
            var users = await _userRepository.GetAsync(id);
            if (users != null)
            {
                _userRepository.Delete(id);
                return users;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> UpdateUser(User user)
        {
            var users = await _userRepository.GetAsync(user.UserId);
            if (users != null)
            {
                users.Email = user.Email;
                users.Password = user.Password;
                users.isEventOrginizer= user.isEventOrginizer;
                return await _userRepository.Update(users);
            }
            throw new NoSuchUserException();
        }


    }
}
