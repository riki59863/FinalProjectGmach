using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LoginBl : ILoginBl
    {
        public ILoginDl _logindl;
        public LoginBl(ILoginDl loginDL)
        {
            _logindl = loginDL;
        }
        public async Task<User> addUser(User user)
        {
            return await _logindl.addUser(user);
        }
        public async Task<User> updateuser(User user)
        {
            return await _logindl.updateUser(user);
        }
        public async Task<User> deleteUser(User user)
        {
            return await _logindl.deleteUser(user);
        }
    }
}
