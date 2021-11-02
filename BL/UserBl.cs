using DL;
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class UserBl : IUserBl
    {
        public IUserDl userDl;

        public UserBl(IUserDl _userDl)
        {
            userDl = _userDl;
        }
        public async Task<int> addUser(User user)
        {
            //User u = await userDl.getUserByIdentityNumber(user.IdentityNumber);
            //if (u == null)
                return await userDl.addUser(user);
            //else
            //{
            //    User us = new User();
            //        us = await userDl.updateUser(user);
            //    return us.Id;
            //}
        }
        public async Task<User> getUserByIdentityNumber(string identityNumber)
        {
            return await userDl.getUserByIdentityNumber(identityNumber);
        }
        public User getUserByIdentity(string identityNumber)
        {
            return userDl.getUserByIdentity(identityNumber);
        }
        public async Task<User> updateuser(User user)
        {
            return await userDl.updateUser(user);
        }
        public async Task<User> deleteUser(int userId)
        {

            return await userDl.deleteUser(userId);
        }
        public List<string> getAddress(string str)
        {
            return userDl.getAddress(str);
        }

        public async Task<List<User>> getAllUsers(DTO_UserParams dTO_UserParams)
        {
            return await userDl.getAllUsers(dTO_UserParams);
        }

        public async Task<User> getUserById(int userId)
        {
            return await userDl.getUserById(userId);
        }

    }
}

