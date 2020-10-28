using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int userId);

        User CreateUser(UserSummary userSummary);

        User EditUser(UserSummary userSummary, int userId);

        void RemoveUser(int userId);

        bool UpdateUserActivity(int userId, bool isActive);

        IEnumerable<User> GetStoreUsers(int storeId);

        bool DoesUserExists(int userId);
    }
}
