using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IuserBL
    {
        Task<User> getUser(string name, string pswd);
        Task postUser(User value);
        Task putUser(int id, User userUpdate);
    }
}