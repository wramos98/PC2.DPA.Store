using Microsoft.EntityFrameworkCore;
using PC2.DPA.Store.DOMAIN.Core.Entities;
using PC2.DPA.Store.DOMAIN.Core.Interfaces;
using PC2.DPA.Store.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC2.DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(String email, String password)
        {
            return await _context.User.Where(x => x.Email == email && password == password).FirstOrDefaultAsync();
            //return await _context.User.FindAsync(email, password);
        }


        public async Task<bool> Insert(User user)
        {
            await _context.User.AddAsync(user);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(User user)
        {
            _context.User.Update(user);
            var CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }


        public async Task<bool> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return false;

            _context.User.Remove(user);
            var CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }





    }
}
