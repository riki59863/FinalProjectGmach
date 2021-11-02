using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBl
    {
        Task<User> getUserByIdentityNumber(string identityNumber);
        User getUserByIdentity(string identityNumber);
        Task<int> addUser(User user);
        Task<User> deleteUser(int userId);
        Task<User> updateuser(User user);
        Task<List<User>> getAllUsers(DTO_UserParams dTO_UserParams);
        Task<User> getUserById(int userId);
        List<string> getAddress(string str);
    }
}
