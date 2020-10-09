using DomainModels;
using System.Collections.Generic;
using System.Linq;
namespace ApplicationServices.Containers
{
    public static class UserContainer
    {
        private static int currentPrimaryId = 1;

        private static List<User> users { get; set; }

        static UserContainer()
        {
            initUsers();
        }

        private static void initUsers()
        {
            users = new List<User>();

            var user1 = new User(currentPrimaryId)
            {
                Email = "test@test.com",
                FirstName = "Dan",
                LastName = "Nouer",
                IsActive = true,
                StoreID = 1
            };

            users.Add(user1);
        }

        public static List<User> GetAll() => users;

        public static User GetById(int userId)
        {
            return users.First(x => x.ID == userId);
        }

        public static User AddUser(User user)
        {
            var savingUser = new User(currentPrimaryId)
            {
                StoreID = user.StoreID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true
            };

            users.Add(savingUser);
            currentPrimaryId++;
            return savingUser;
        }

        public static User UpdateUser(User user)
        {
            var updatingUser = users.First(x => x.ID == user.ID);

            updatingUser.StoreID = user.StoreID;
            updatingUser.Email = user.Email;
            updatingUser.FirstName = user.FirstName;
            updatingUser.LastName = user.LastName;
            updatingUser.IsActive = true;
            return updatingUser;
        }

        public static void RemoveUser(int userId)
        {
            var removingUser = users.First(x => x.ID == userId);
            users.Remove(removingUser);
        }
    }
}
