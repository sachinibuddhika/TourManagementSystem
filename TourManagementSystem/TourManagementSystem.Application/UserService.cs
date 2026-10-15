using System;
using System.Collections.Generic;
using System.Text;
using TourManagementSystem.Domain;


namespace TourManagementSystem.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllUsers()
        {
            return  _userRepository.GetAllUsers();
        }

        public Task<User?> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public Task AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return null;
            }
            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;

            await _userRepository.UpdateUser(existingUser);
            return existingUser;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var user=await _userRepository.GetUserById(id);

            if (user == null) {
                return false;
            }
            await _userRepository.DeleteUserById(user);
            return true;
        }
    }

}
