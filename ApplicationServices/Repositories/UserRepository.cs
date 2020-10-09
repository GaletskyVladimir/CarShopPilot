using ApplicationServices.Containers;
using ApplicationServices.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            try
            {
                return UserContainer.AddUser(user);
            }
            catch(Exception ex)
            {
                //todo throw custom ex;
                throw ex;
            }
        }

        public List<User> GetAll()
        {
            return UserContainer.GetAll();
        }

        public User GetById(int userId)
        {
            return UserContainer.GetById(userId);
        }

        public User ModifyUser(User user)
        {
            return UserContainer.UpdateUser(user);
        }

        public void RemoveUser(int userId)
        {
            UserContainer.RemoveUser(userId);
        }
    }
}
