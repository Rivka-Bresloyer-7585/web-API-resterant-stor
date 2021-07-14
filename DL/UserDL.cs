
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        ApiDBContext _db;
        public UserDL(ApiDBContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }

        public async Task<User> getUser(string email, string pswd)
        {
            User user1 = await _db.User.Where(u=> u.Email.Equals(email) && u.Password.Equals(pswd)).FirstOrDefaultAsync();
            return user1;
        }

        public async Task putUser(int id, User userUpdate)
        {
            var user = await _db.User.FindAsync(id);
            if (userUpdate != null)
            {
                userUpdate.UserId = user.UserId;
                _db.Entry(user).CurrentValues.SetValues(userUpdate);
                await _db.SaveChangesAsync();
            }
        }

        public async Task postUser(User value)
        {
            await _db.User.AddAsync(value);
            await _db.SaveChangesAsync();
        }
    }
}