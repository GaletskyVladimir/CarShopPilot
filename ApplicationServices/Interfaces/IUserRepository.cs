using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int userId);

        User AddUser(User user);

        User ModifyUser(User user);

        void RemoveUser(int userId);

        bool UpdateActivity(int userId, bool isActive);

        IEnumerable<User> GetStoreUsers(int storeId);

        bool DoesUserExists(int userId);
    }
}
