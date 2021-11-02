

using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDl
    {
        Task<int> addUser(User user);
        Task<User> deleteUser(int userId);
        Task<User> updateUser(User user);
        Task<List<User>> getAllUsers(DTO_UserParams dTO_UserParams);
        Task<User> getUserByIdentityNumber(string identityNumber);
        User getUserByIdentity(string identityNumber);
        Task<User> getUserById(int userId);
        List<string> getAddress(string str);
    }
}

