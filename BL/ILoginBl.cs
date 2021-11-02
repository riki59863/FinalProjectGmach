using Entities.Models;
using System.Threading.Tasks;

namespace BL
{
    public interface ILoginBl
    {
        Task<User> addUser(User user);
        Task<User> deleteUser(User user);
        Task<User> updateuser(User user);
    }
}