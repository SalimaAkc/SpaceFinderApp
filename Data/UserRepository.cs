using Microsoft.EntityFrameworkCore;
using SpacefinderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacefinderApp.Data
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}