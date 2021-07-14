using DL;
using Entities;
using System.Threading.Tasks;

namespace BL
{
    public class userBL : IuserBL
    {
        IUserDL _iuserDL;
        public userBL(IUserDL iuserDL)
        {
            _iuserDL = iuserDL;
        }

        public async Task<User> getUser(string name, string pswd)
        {
          return await _iuserDL.getUser(name, pswd);
         }
        public async Task putUser(int id, User userUpdate)
        {
            await _iuserDL.putUser(id, userUpdate);
        }
        public async Task postUser(User value)
        {
            await _iuserDL.postUser(value);
        }
    }
}
