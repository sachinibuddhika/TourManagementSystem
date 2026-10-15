using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TourManagementSystem.Application;
using TourManagementSystem.Domain;

namespace TourManagementSystem.Infrastructure
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDBContext _db;

        public UserRepository(AppDBContext db) => _db = db;

        public Task<List<User>> GetAllUsers() => _db.Users.ToListAsync();
        public Task<User?> GetUserById(int id) =>  _db.Users.FindAsync(id).AsTask();
        public  Task AddUser(User user) { _db.Users.Add(user); return  _db.SaveChangesAsync(); }
        public Task UpdateUser(User user) { _db.Users.Update(user);  return _db.SaveChangesAsync(); }
        public Task DeleteUserById(User user ) { _db.Users.Remove(user); return _db.SaveChangesAsync(); }

    }
}

