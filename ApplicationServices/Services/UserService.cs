using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int userId)
        {
            return userRepository.GetById(userId);
        }

        public User CreateUser(UserSummary userSummary)
        {
            //todo mapper
            var user = new User
            {
                Email = userSummary.Email,
                StoreID = userSummary.StoreID,
                FirstName = userSummary.FirstName,
                LastName = userSummary.LastName,
                IsActive = userSummary.IsActive
            };
            return userRepository.AddUser(user);
        }

        public User EditUser(UserSummary userSummary, int userId)
        {
            var user = userRepository.GetById(userId);
            user.Email = userSummary.Email;
            user.StoreID = userSummary.StoreID;
            user.FirstName = userSummary.FirstName;
            user.LastName = userSummary.LastName;
            user.IsActive = userSummary.IsActive;
            return userRepository.ModifyUser(user);
        }

        public void RemoveUser(int userId)
        {
            userRepository.RemoveUser(userId);
        }

        public bool UpdateUserActivity(int userId, bool isActive)
        {
            return userRepository.UpdateActivity(userId, isActive);
        }

        public IEnumerable<User> GetStoreUsers(int storeId)
        {
            //store validation
            return userRepository.GetStoreUsers(storeId);
        }

        public bool DoesUserExists(int userId)
        {
            return userRepository.DoesUserExists(userId);
        }
    }
}
