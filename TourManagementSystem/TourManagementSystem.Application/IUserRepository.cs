using System;
using System.Collections.Generic;
using System.Text;
using TourManagementSystem.Domain;

namespace TourManagementSystem.Application
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUserById(User user);
    }
}
